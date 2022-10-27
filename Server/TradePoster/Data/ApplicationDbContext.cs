using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TradePoster.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<LoginSources> LoginSources { get; set; }
        public virtual DbSet<Announcements> Announcements { get; set; }
        public virtual DbSet<Banners> Banners { get; set; }
    }
}
