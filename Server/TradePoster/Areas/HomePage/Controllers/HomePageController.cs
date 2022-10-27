using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.AUTH;
using TradePoster.Data;
using TradePoster.Services.HomePage;

namespace TradePoster.Areas.HomePage.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomePageController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		private readonly IHomePageService _homePageService;
		public HomePageController(
		   IHomePageService homePageService, ApplicationDbContext context)
		{
			_context = context;
			_homePageService = homePageService;
		}
		[AppAuthorize(false, false)]
		[Route("GetAnnouncement")]
		[HttpGet]
		public async Task<IActionResult> GetAnnouncement()
		{
			var result = await _homePageService.GetAnnouncement();
			return StatusCode(StatusCodes.Status200OK, result);
		}
		[AppAuthorize(false, false)]
		[Route("AddAnnouncement")]
		[HttpPost]
		public async Task<IActionResult> AddAnnouncement(Announcements model)
		{
			var result = await _homePageService.AddAnnouncement(model);
			return StatusCode(StatusCodes.Status200OK, result); 
		}
		[AppAuthorize(false, false)]
		[Route("ActiveAnnouncement")]
		[HttpPost]
		public async Task<IActionResult> ActiveAnnouncement(int Id, string userId)
		{
			var result = await _homePageService.ActiveAnnouncement(Id,userId);
			return StatusCode(StatusCodes.Status200OK, result); 
		}
		[AppAuthorize(false, false)]
		[Route("AddBanner")]
		[HttpPost]
		public async Task<IActionResult> AddBanner(Banners Model)
		{
			var result = await _homePageService.AddBanner(Model);
			return StatusCode(StatusCodes.Status200OK, result); 
		}
		[AppAuthorize(false, false)]
		[Route("GetBanner")]
		[HttpGet]
		public async Task<IActionResult> GetBanner()
		{
			var result = await _homePageService.GetBanners();
			return StatusCode(StatusCodes.Status200OK, result); 
		}
		[AppAuthorize(false, false)]
		[Route("DeleteBanner")]
		[HttpPost]
		public async Task<IActionResult> DeleteBanner(int Id)
		{
			var result = await _homePageService.DeleteBanner(Id);
			return StatusCode(StatusCodes.Status200OK, result); 
		}
	}
}
