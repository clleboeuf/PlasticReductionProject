using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PlasticReductionProject.Models;

namespace PlasticReductionProject.DAL
{
    public class PlasticDbContext : DbContext
    {
        public PlasticDbContext() : base("name=PlasticDbContext")
        {
            Database.SetInitializer(new PlasticDbInitializer());
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Project> Projects { get; set; }    
        public DbSet<DictionaryWord> Dictionary { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PlasticAlternative> Alternatives { get; set; }
        public DbSet<PlasticType> PlasticTypes { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<PlasticFact> PlasticFacts { get; set; }
        public DbSet<Character> Characters { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}