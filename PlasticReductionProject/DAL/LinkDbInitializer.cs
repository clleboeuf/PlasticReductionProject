using PlasticReductionProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace PlasticReductionProject.DAL
{
    internal class LinkDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<LinkDbContext>  //  DropCreateDatabaseIfModelChanges<ItemDbContext>  or DropCreateDatabaseAlways<ItemDbContext>
    {
        protected override void Seed(LinkDbContext context)
        {
            var links = new List<Link>
            {
            new Link{Description="Gardening Equipment and Tools",Url="test",Image="blah"},
            new Link{Description="Another Record",Url="test",Image="blah"}
            };
            links.ForEach(i => context.Links.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}