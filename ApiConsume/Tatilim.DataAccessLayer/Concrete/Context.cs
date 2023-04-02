using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-491CL38\\YAYLALISERVER22;database=TatilimDB;Trusted_Connection=True;");
        }
        public DbSet<Room>  Rooms { get; set; }
        public DbSet<Service>  Services { get; set; }
        public DbSet<Staff>  Staffs { get; set; }
        public DbSet<Subscribe>  Subscribes { get; set; }
        public DbSet<Testimonial>  Testimonials { get; set; }
    }
}
