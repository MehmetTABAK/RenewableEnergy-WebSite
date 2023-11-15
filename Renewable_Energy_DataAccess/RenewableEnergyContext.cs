using Microsoft.EntityFrameworkCore;
using Renewable_Energy_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewable_Energy_DataAccess
{
    public class RenewableEnergyContext : DbContext
    {
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Blog> Blogs{ get; set; }
        public virtual DbSet<BlogCategory> BlogCategories{ get; set; }
        public virtual DbSet<Project> Projects{ get; set; }
        public virtual DbSet<ProjectCategory> ProjectCategories{ get; set; }
        public virtual DbSet<ProjectBlogRelation> ProjectBlogRelations{ get; set; }
        public virtual DbSet<Reference> References{ get; set; }
        public virtual DbSet<WorkingArea> WorkingAreas{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=RenewableEnergy");
        }
    }
}
