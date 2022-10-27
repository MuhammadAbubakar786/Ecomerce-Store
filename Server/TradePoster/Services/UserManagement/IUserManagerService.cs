using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Data;
using TradePoster.Models.Common;

namespace TradePoster.Services.UserManagement
{
   public interface IUserManagerService
    {
        public  Task<keyValueResponse<int>> UpdateUserProfile(UserProfile profile);

    }
}
