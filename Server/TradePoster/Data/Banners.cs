using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TradePoster.Models.Common;

namespace TradePoster.Data
{
	public class Banners:AuditableEntries
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[Required]
		public string BannerImage { get; set; }
		[MaxLength(25)]
		public string Title { get; set; }
		[MaxLength(50)]
		public string Description { get; set; }
		[NotMapped]
		public string UserId { get; set; }

	}
}
