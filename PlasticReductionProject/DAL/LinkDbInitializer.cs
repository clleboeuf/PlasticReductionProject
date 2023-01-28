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
            new Link{Description="Click the logo to go to the World Wildlife Fund's page on plastic pollution in Australia which provides a lot of information on the effect that plastic has on the animals in the natural world.",Url="https://www.wwf.org.au/get-involved/plastic-pollution/stopping-plastic-pollution",Image="../Images/LinksImages/WWFLogo.jpg"},
            new Link{Description="The Plastic Soup Foundation provides information  on the effect that plastic has on the oceans and also has a lot of information about how plastic is getting into our food sources.  If you click the logo you will be taken to their website where you can find a lot of information to help you make a difference.",Url="https://www.plasticsoupfoundation.org/en/",Image="../Images/LinksImages/PSFlogo.jpg" },
            new Link{Description="The United Nations Environment Programme provides global information about plastic pollution and will tell you about efforts around the world to stop the pollution of our environment by plastic.  Just click the log to find out more.",Url="https://www.unep.org/plastic-pollution",Image="../Images/LinksImages/UNEPLogo.png"}

            };
            links.ForEach(i => context.Links.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}