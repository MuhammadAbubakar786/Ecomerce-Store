using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradePoster.Models.Common
{
	public class AuditableEntries
	{
		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}
