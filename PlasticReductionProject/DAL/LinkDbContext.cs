using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PlasticReductionProject.Models;

namespace PlasticReductionProject.DAL
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext() : base("LinkDbContext")
        {
            Database.SetInitializer(new LinkDbInitializer());
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Project> Projects { get; set; }    
        public DbSet<DictionaryWord> Dictionary { get; set; }

    //    public DbSet<Product> Products { get; set; }
        public DbSet<PlasticAlternative> Alternatives { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}