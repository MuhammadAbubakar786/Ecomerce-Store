using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Data;
using TradePoster.Data.ViewModel;

namespace TradePoster.Models.Common
{
    public class Response
    {
    }
    public class keyValueResponse<T>
    {
        public string status { get; set; }
        public T key { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public string token { get; set; }
        public IList<UserRolesVm> UserRoles { get; set; }
    }
}
