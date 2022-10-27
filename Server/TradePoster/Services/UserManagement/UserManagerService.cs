using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Data;
using TradePoster.Models.Common;

namespace TradePoster.Services.UserManagement
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ApplicationDbContext _context;
        public UserManagerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<keyValueResponse<int>> UpdateUserProfile(UserProfile model)
        {
            var entry = _context.UserProfile.Where(d => d.UserId == model.UserId);
            if (entry.Count() < 1)
            {
                try
                {
                    _context.UserProfile.Add(model);
                    await _context.SaveChangesAsync();
                    return new keyValueResponse<int>() { status = "success", key = model.Id };
                }
                catch (Exception e)
                {

                    throw;
                }

            }
            else
            {
                try
                {
                    var data = entry.FirstOrDefault();
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.InstagramUrl = model.InstagramUrl;
                    data.FacebookUrl = model.FacebookUrl;
                    data.LinkedInUrl = model.LinkedInUrl;
                    data.TwitterUrl = model.TwitterUrl;
                    data.GooglePlusUrl = model.GooglePlusUrl;
                    data.YouttubeUrl = model.YouttubeUrl;
                    data.UserId = model.UserId;
                    data.PhoneNumber = model.PhoneNumber;
                    await _context.SaveChangesAsync();
                    model.Id = data.Id;
                    return new keyValueResponse<int> { status = "success", key= data.Id  };
                }
                catch (Exception e)
                {

                    return new keyValueResponse<int> { status = "false", key = 0,text=e.Message };

                }

            }
        }

      
    }
}
