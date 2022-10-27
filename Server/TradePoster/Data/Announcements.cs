using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Models.Common;

namespace TradePoster.Data
{
	public class Announcements : AuditableEntries
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AnnouncementId { get; set; }
		public string Description { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public bool IsDeleted { get; set; }
		public bool Active { get; set; }
		[NotMapped]
		public string UserId { get; set; }

	}
}
