using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Data;
using TradePoster.Models.Common;

namespace TradePoster.Services.HomePage
{
	public class HomePageService : IHomePageService
	{
		private readonly ApplicationDbContext _context;
		public HomePageService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<keyValueResponse<List<Announcements>>> GetAnnouncement()
		{
			var Latestannouncement = await _context.Announcements.Where(e=>e.IsDeleted != true).ToListAsync();
			return new keyValueResponse<List<Announcements>> { status = "success", key = Latestannouncement };
		}
		public async Task<keyValueResponse<Announcements>> AddAnnouncement(Announcements model)
		{
			if (model.AnnouncementId != 0)
			{
				var data = _context.Announcements.Find(model.AnnouncementId);
				model.Active = false;
				model.CreatedDate = data.CreatedDate;
				model.CreatedBy = data.CreatedBy;
				model.UpdatedDate = DateTime.Now;
				model.UpdatedBy = model.UserId;
				_context.Update(model);
				await _context.SaveChangesAsync();
				return new keyValueResponse<Announcements> { status = "success", key = model };
			}
			else
			{
				model.CreatedDate = DateTime.Now;
				model.CreatedBy = model.UserId;
				model.UpdatedDate = null;
				model.UpdatedBy = null;
				model.Active = false;
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();
				return new keyValueResponse<Announcements> { status = "success", key = model };
			}
		}
		public async Task<keyValueResponse<Announcements>> ActiveAnnouncement(int Id,string userId)
		{
			var getActiveAnnouncement = _context.Announcements.Where(e => e.Active == true).FirstOrDefault();
			if (getActiveAnnouncement != null)
			{
				getActiveAnnouncement.Active = false;
				getActiveAnnouncement.UpdatedDate = DateTime.Now;
				getActiveAnnouncement.UpdatedBy = userId;
				_context.Update(getActiveAnnouncement);
				await _context.SaveChangesAsync();
			}
			
				var data = _context.Announcements.Find(Id);
				data.Active = true;
				data.UpdatedDate = DateTime.Now;
				data.UpdatedBy = userId;
				_context.Update(data);
				await _context.SaveChangesAsync();
				return new keyValueResponse<Announcements> { status = "success", key = data };
		}
		public async Task<keyValueResponse<Banners>> AddBanner(Banners model)
		{
			if (model.ID != 0)
			{
				var data = _context.Banners.Find(model.ID);
				model.CreatedDate = data.CreatedDate;
				model.CreatedBy = data.CreatedBy;
				model.UpdatedDate = DateTime.Now;
				model.UpdatedBy = model.UserId;
				_context.Update(model);
				await _context.SaveChangesAsync();
				return new keyValueResponse<Banners> { status = "success", key = model };
			}
			else
			{
				model.CreatedDate = DateTime.Now;
				model.CreatedBy = model.UserId;
				model.UpdatedDate = null;
				model.UpdatedBy = null;
				await _context.AddAsync(model);
				await _context.SaveChangesAsync();
				return new keyValueResponse<Banners> { status = "success", key = model };
			}
		}
		public async Task<keyValueResponse<List<Banners>>> GetBanners()
		{
			var data = await _context.Banners.ToListAsync();
			return new keyValueResponse<List<Banners>> { status = "success", key = data };
		}
		public async Task<keyValueResponse<int>> DeleteBanner(int Id)
		{
			var data = await _context.Banners.FindAsync(Id);
			 _context.Banners.Remove(data);
			await _context.SaveChangesAsync();
			return new keyValueResponse<int> { status = "success", key = data.ID };
		}
	}
}
