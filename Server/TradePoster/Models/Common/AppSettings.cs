using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradePoster.Models.Common
{
    public class AppSettings
    {
        public string BASE_URL { get; set; }
        public string SecretKey { get; set; }

    }
    
    public class EmailConfigurationData
    {
        public string Mail { get; set; }
        public string Password { get; set; }

    }

}
