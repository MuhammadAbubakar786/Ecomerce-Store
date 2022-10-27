using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Data;
using TradePoster.Models.Common;

namespace TradePoster.Services.HomePage
{
   public interface IHomePageService
    {
        public Task<keyValueResponse<List<Announcements>>> GetAnnouncement();
        public Task<keyValueResponse<Announcements>> AddAnnouncement(Announcements model);
        public Task<keyValueResponse<Announcements>> ActiveAnnouncement(int Id , string userId);
        public Task<keyValueResponse<Banners>> AddBanner(Banners model);
        public Task<keyValueResponse<List<Banners>>> GetBanners();
        public Task<keyValueResponse<int>> DeleteBanner(int Id);

    }
}
