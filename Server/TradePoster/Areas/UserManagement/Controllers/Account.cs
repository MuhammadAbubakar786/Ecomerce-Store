using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TradePoster.Areas.UserManagement.Models;
using TradePoster.AUTH;
using TradePoster.Data;
using TradePoster.Data.ViewModel;
using TradePoster.Models.Common;
using TradePoster.Services.UserManagement;
using TradePoster.Utilities;

namespace TradePoster.Areas.UserManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Account : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private AppSettings _appSettings { get; set; }
		private EmailConfigurationData _emailConfigurationData { get; set; }
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;
		private readonly IUserManagerService _userManagementService;
		private readonly AuthorizationFilterContext filterContext;

		public Account(
		  UserManager<IdentityUser> userManager,
		  SignInManager<IdentityUser> signInManager,
		  RoleManager<IdentityRole> roleManager,
		  ILogger<RegisterModel> logger,
		  IEmailSender emailSender, IOptions<AppSettings> settings, IOptions<EmailConfigurationData> emailSetting, ApplicationDbContext context, IHostingEnvironment environment, IUserManagerService userManagerService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
			_appSettings = settings.Value;
			_emailConfigurationData = emailSetting.Value;
			_context = context;
			_hostingEnvironment = environment;
			_userManagementService = userManagerService;

		}
		[AppAuthorize(false, false)]
		[Route("RegisterAccount")]
		[HttpPost]
		public async Task<IActionResult> SellerRegisterAccount(AuthenticationModel model)
		{

			if (ModelState.IsValid)
			{
				if (model.Source == globals.FACEBOOK_SOURCE || model.Source == globals.GMAIL_SOURCE)
				{
					var existing = await _userManager.FindByEmailAsync(model.Email);
					if (existing != null)
					{
						var existingsignup = _context.LoginSources.Where(d => d.UserId == existing.Id);
						if (existingsignup.Count() < 1)
						{
							_context.LoginSources.Add(new LoginSources()
							{
								Source = model.Source,
								UserId = existing.Id
							});
							_context.SaveChanges();
						}
					
						var getUserRole = _userManager.GetUsersInRoleAsync(model.Role).Result.Where(e => e.Id == existing.Id).ToList();
						if (getUserRole.Count() <= 0)
						{
							var GetRole = _roleManager.FindByNameAsync(model.Role).Result;
							if (GetRole != null)
							{
								await _userManager.AddToRoleAsync(existing, GetRole.Name);
							}
						}
						var token = globals.GetToken(new AuthToken { UserId = existing.Id, UserName = existing.Email }, 60, _appSettings);
						return StatusCode(StatusCodes.Status200OK, new keyValueResponse<IdentityUser>() { status = "success", key = existing, token = token });
					}
					else
					{

						var user = new IdentityUser { UserName = model.UserName, Email = model.Email, EmailConfirmed = model.EmailVerified, NormalizedUserName = model.UserName };
						var result = await _userManager.CreateAsync(user, model.Password);
						if (result.Succeeded)
						{
							_logger.LogInformation("User created a new account with password.");
							_context.LoginSources.Add(new LoginSources()
							{
								Source = model.Source,
								UserId = user.Id
							});
							//Assign Role to User
							var GetRole = _roleManager.FindByNameAsync(model.Role).Result;
							if (GetRole != null)
							{
								await _userManager.AddToRoleAsync(user, GetRole.Name);
							}
							_context.SaveChanges();
							var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
							code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
							var callbackUrl = Url.Page(
								"/Account/ConfirmEmail",
								pageHandler: null,
								values: new { area = "Identity", userId = user.Id, code = code, returnUrl = "" },
								protocol: Request.Scheme);

							var token = globals.GetToken(new AuthToken { UserId = user.Id, UserName = user.Email }, 60, _appSettings);
							return StatusCode(StatusCodes.Status200OK, new keyValueResponse<IdentityUser>() { status = "success", key = user, token = token });

						}
					}
				}
				else
				{
					var user = new IdentityUser { UserName = model.Email, Email = model.Email, EmailConfirmed = model.EmailVerified, NormalizedUserName = model.UserName };
					var existing = await _userManager.FindByEmailAsync(model.Email);
					if (existing != null)
					{
						var getUserRole = _userManager.GetUsersInRoleAsync(model.Role).Result.Where(e => e.Id == existing.Id).ToList();
						if (getUserRole.Count() <= 0)
						{
							var GetRole = _roleManager.FindByNameAsync(model.Role).Result;
							if (GetRole != null)
							{
								await _userManager.AddToRoleAsync(existing, GetRole.Name);
							}
						}
						var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
						var callbackUrl = Url.Page(
							"/Account/ConfirmEmail",
							pageHandler: null,
							values: new { area = "Identity", userId = existing.Id, code = code, returnUrl = "" },
							protocol: Request.Scheme);

						var token = globals.GetToken(new AuthToken { UserId = existing.Id, UserName = existing.Email }, 60, _appSettings);
						return StatusCode(StatusCodes.Status200OK, new keyValueResponse<IdentityUser>() { status = "success", key = existing, token = token });
					}
					else
					{
						var result = await _userManager.CreateAsync(user, model.Password);
						if (result.Succeeded)
						{

							_logger.LogInformation("User created a new account with password.");
							_context.LoginSources.Add(new LoginSources()
							{
								Source = globals.DEFAULT_SOURCE,
								UserId = user.Id
							});
							_context.SaveChanges();
							try
							{
								
								//Assign Role to User
								var GetRole = _roleManager.FindByNameAsync(model.Role).Result;
								if (GetRole != null)
								{
									await _userManager.AddToRoleAsync(user, GetRole.Name);
								}
								_context.SaveChanges();
							}
							catch (Exception ex)
							{

								throw;
							}
							var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
							code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
							var callbackUrl = Url.Page(
								"/Account/ConfirmEmail",
								pageHandler: null,
								values: new { area = "Identity", userId = user.Id, code = code, returnUrl = "" },
								protocol: Request.Scheme);
							var token = globals.GetToken(new AuthToken { UserId = user.Id, UserName = user.Email }, 60, _appSettings);
							var UserRolesList = new List<UserRolesVm>();
							var userRoles = _userManager.GetRolesAsync(user);
							foreach (var item in userRoles.Result)
							{
								var role = _roleManager.FindByNameAsync(item);
								var UserRoleManager = new UserRolesVm
								{
									RoleId = role.Result.Id,
									RoleName = role.Result.Name,
									UserId = user.Id,
								};
								UserRolesList.Add(UserRoleManager);
							}
							return StatusCode(StatusCodes.Status200OK, new keyValueResponse<IdentityUser>() { status = "success", key = user, token = token, UserRoles = UserRolesList });

						}
					}

				}


			}
			return StatusCode(StatusCodes.Status404NotFound, new keyValueResponse<IdentityUser>() { status = "failed", key = new IdentityUser(), token = "" });
		}
		[AppAuthorize(false, false)]
		[Route("UserSignIn")]
		[HttpPost]
		public async Task<IActionResult> UserSignIn(AuthenticationModel model)
		{
			try
			{


				if (ModelState.IsValid)
				{
					// This doesn't count login failures towards account lockout
					// To enable password failures to trigger account lockout, set lockoutOnFailure: true
					var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
					if (result.Succeeded)
					{
						_logger.LogInformation("User logged in.");
						var user = _userManager.FindByEmailAsync(model.Email).Result;
						var token = globals.GetToken(new AuthToken { UserId = user.Id, UserName = user.Email }, 60, _appSettings);
						var UserRolesList = new List<UserRolesVm>();
						var userRoles = _userManager.GetRolesAsync(user);
						foreach (var item in userRoles.Result)
						{
							var role = _roleManager.FindByNameAsync(item);
							var UserRoleManager = new UserRolesVm
							{
								RoleId = role.Result.Id,
								RoleName = role.Result.Name,
								UserId = user.Id,
							};
							UserRolesList.Add(UserRoleManager);
						}
						var resp = new keyValueResponse<IdentityUser>() { status = "success", key = user, token = token, UserRoles = UserRolesList };
						return StatusCode(StatusCodes.Status200OK, resp);
					}
					//if (result.RequiresTwoFactor)
					//{
					//    return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<string>() { key = new IdentityUser() });
					//    //  return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
					//}
					if (result.IsLockedOut)
					{
						//_logger.LogWarning("User account locked out.");
						//return RedirectToPage("./Lockout");
						return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<string>() { status = "failed", key = "User account locked out.", token = "" });
					}
					else
					{
						ModelState.AddModelError(string.Empty, "Invalid login attempt.");
						return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<string>() { key = "Invalid login attempt.", status = "failed", token = "" });
					}
				}

			}
			catch (Exception rx)
			{


			}
			// If we got this far, something failed, redisplay form
			return StatusCode(StatusCodes.Status404NotFound, new keyValueResponse<IdentityUser>() { status = "failed", key = new IdentityUser(), token = "" });
		}
		[AppAuthorize(false, false)]
		[Route("ForgotPassword")]
		[HttpPost]
		public async Task<IActionResult> ForgotPassword(AuthenticationModel model)
		{

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
			{
				// Don't reveal that the user does not exist or is not confirmed
				return StatusCode(StatusCodes.Status404NotFound, new keyValueResponse<IdentityUser>() { status = "failed", key = new IdentityUser(), token = "" });
			}

			// For more information on how to enable account confirmation and password reset please 
			// visit https://go.microsoft.com/fwlink/?LinkID=532713
			var code = await _userManager.GeneratePasswordResetTokenAsync(user);
			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
			var callbackUrl = globals.SERVER_URL + "/#/ResetPassword?code=" + code;
			
			await _emailSender.SendEmailAsync(
				model.Email,
				"Reset Password",
				$"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}&email=" + model.Email + ">clicking here</a>.");

			return StatusCode(StatusCodes.Status200OK, new keyValueResponse<Microsoft.AspNetCore.Identity.SignInResult>() { status = "success" });

		}
		[AppAuthorize(false, false)]
		[Route("ResetPassword")]
		[HttpPost]
		public async Task<IActionResult> ResetPassword(AuthenticationModel model)
		{

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<string>() { key = "Invalid login attempt.", status = "failed", token = "" });
			}
			model.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
			{
				var token = globals.GetToken(new AuthToken { UserId = user.Id, UserName = user.Email }, 60, _appSettings);
				return StatusCode(StatusCodes.Status200OK, new keyValueResponse<Microsoft.AspNetCore.Identity.SignInResult>() { status = "success", token = token });
			}

			return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<string>() { key = "Invalid reset attempt.", status = "failed", token = "" });

		}
		[AppAuthorize(false, false)]
		[Route("UploadFile")]
		[HttpPost]
		public async Task<IActionResult> UploadFile()
		{
			try
			{
				string contentPath = _hostingEnvironment.WebRootPath + "\\Uploads";
				string guid = globals.GenerateGUID();
				string path = Path.Combine(contentPath, guid);
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				string filePath = "/Uploads/" + guid;
				foreach (var file in Request.Form.Files)
				{

					string fileType = Path.GetExtension(file.FileName);
					string fileName = DateTime.Now.ToString("yyyyddmmhhmsFFFFF") + fileType;
					//string removeSpaceFileName =  string.Join("", fileName.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
					filePath += "/" + fileName;
					Stream imageStream = file.OpenReadStream();

					using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
					{
						file.CopyTo(stream);
					}

				}
				return StatusCode(StatusCodes.Status200OK, new keyValueResponse<string>() { status = "success", key = filePath });
			}
			catch (Exception ec)
			{


				return StatusCode(StatusCodes.Status200OK, new keyValueResponse<string>() { status = "error", key = ec.Message });
			}
		}
		[AppAuthorize(false, false)]
		[Route("UpdateUserProfile")]
		[HttpPost]
	
		[AppAuthorize(false, false)]
		[Route("GetUserProfile")]
		[HttpPost]
		public async Task<IActionResult> GetUserProfile(string userId, string flag)
		{
			var entry = _context.UserProfile.Where(d => d.UserId == userId).FirstOrDefault();
			var user = await _userManager.FindByIdAsync(userId);
			var getUserRoles = _userManager.GetRolesAsync(user).Result.ToList();
			if (flag == null)
			{
				foreach (var item in getUserRoles)
				{
					if (item == "Seller")
					{
						entry.UserRole = "Seller";

					}
				}
				if (entry.UserRole == null)
				{
					if (getUserRoles.FirstOrDefault() == "User")
					{
						entry.UserRole = "User";
					}
				}
			}
			else
			{
				foreach (var item in getUserRoles)
				{
					if (item == flag)
					{
						entry.UserRole = flag;
					}
				}
			}
			if (entry.UserRole == null)
			{
				//Assign Role to User
				var GetRole = _roleManager.FindByNameAsync(flag).Result;
				if (GetRole != null)
				{
					await _userManager.AddToRoleAsync(user, GetRole.Name);
				}
				var checkAgainUserRole = _userManager.GetRolesAsync(user).Result.ToList();
				foreach (var item in checkAgainUserRole)
				{
					if (item == flag)
					{
						entry.UserRole = flag;
					}
				}
			}
			if (entry == null)
				return StatusCode(StatusCodes.Status401Unauthorized, new keyValueResponse<UserProfile> { status = "error" });

			return StatusCode(StatusCodes.Status200OK, new keyValueResponse<UserProfile> { status = "success", key = entry });
		}

		[Route("ContactUs")]
		[HttpPost]
		public async Task<ActionResult> ContactUs(string emailFrom, string description, string subject, string contactNo, string name)
		{
			//await _emailSender.SendEmailAsync(emailFrom, subject, description + "<br/>" + name + "<br/>PhoneNo:" + contactNo); here </a>.");

			MailMessage mail = new MailMessage();
			SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
			mail.Subject = subject;
			mail.IsBodyHtml = true;
			mail.Body = description + "<br/>" + name + "<br/>PhoneNo:" + contactNo;
			mail.From = new MailAddress(emailFrom);
			mail.To.Add(new MailAddress(_emailConfigurationData.Mail));
			SmtpServer.Port = 587;
			SmtpServer.Credentials = new System.Net.NetworkCredential(_emailConfigurationData.Mail, _emailConfigurationData.Password);
			SmtpServer.EnableSsl = true;
			SmtpServer.Send(mail);
			return StatusCode(StatusCodes.Status200OK, new keyValueResponse<string>() { key = "Email Send Successfully.", status = "success", }); ;
		}

		[Route("RefreshToken")]
		[HttpPost]
		public string RefreshToken(string email,string userId)
		{
			var token =  globals.GetToken(new AuthToken { UserId = userId, UserName = email }, 5, _appSettings);
			return token;
		}
		//[Route("AddRoles")]
		//[HttpPost]
		//public async Task<ActionResult> CreateRoles()
		//{
		//	var role_Admin = new IdentityRole
		//	{
		//		Name = "Admin",
		//		NormalizedName ="ADMIN"
		//	};
		//	await _roleManager.CreateAsync(role_Admin);

		//	var roleuser = new IdentityRole
		//	{
		//		Name = "User",
		//		NormalizedName="USER"
		//	};
		//	await _roleManager.CreateAsync(roleuser);

		//	var roleseller = new IdentityRole
		//	{
		//		Name = "Seller",
		//		NormalizedName="SELLER"
		//	};
		//	await _roleManager.CreateAsync(roleseller);
		//	return null;
		//}

	}
}
