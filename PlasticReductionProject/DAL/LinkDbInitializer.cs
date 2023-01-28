using PlasticReductionProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace PlasticReductionProject.DAL
{
    internal class LinkDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LinkDbContext>  //  DropCreateDatabaseIfModelChanges<ItemDbContext>  or DropCreateDatabaseAlways<ItemDbContext>
    {
        protected override void Seed(LinkDbContext context)
        {
            var links = new List<Link>
            {
            new Link{Description="Gardening Equipment and Tools"}

            };
            links.ForEach(i => context.Links.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}