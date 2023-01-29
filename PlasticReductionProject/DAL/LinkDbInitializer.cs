using CsvHelper;
using Microsoft.Ajax.Utilities;
using PlasticReductionProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;

namespace PlasticReductionProject.DAL
{

    internal class LinkDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<LinkDbContext>  //  DropCreateDatabaseIfModelChanges<LinkDbContext>  or DropCreateDatabaseAlways<LinkDbContext>

    {
        protected override void Seed(LinkDbContext context)
        {
            var links = new List<Link>
            {
            new Link{Description="Click the logo to go to the World Wildlife Fund's page on plastic pollution in Australia which provides a lot of information on the effect that plastic has on the animals in the natural world.",Url="https://www.wwf.org.au/get-involved/plastic-pollution/stopping-plastic-pollution",Image="../Images/LinksImages/WWFLogo.jpg"},
            new Link{Description="The Plastic Soup Foundation provides information  on the effect that plastic has on the oceans and also has a lot of information about how plastic is getting into our food sources.  If you click the logo you will be taken to their website where you can find a lot of information to help you make a difference.",Url="https://www.plasticsoupfoundation.org/en/",Image="../Images/LinksImages/PSFlogo.jpg" },
            new Link{Description="The United Nations Environment Programme provides global information about plastic pollution and will tell you about efforts around the world to stop the pollution of our environment by plastic.  Just click the log to find out more.",Url="https://www.unep.org/plastic-pollution",Image="../Images/LinksImages/UNEPLogo.png"},
            new Link{Description="As one of the country’s most recognised and trusted environmental organisations, Clean Up Australia has helped Australians take practical environmental action for over 30 years.  In fact Clean Up Australia Day is now the nation's largest community-based environmental event. Find out how Australia has a plastics problem. Australia now produces 2.5 million tonnes of plastic waste each year, equating to 100 kg per person. Of this, only 13% of plastic is recovered and 84% is sent to landfill.",Url="https://www.cleanup.org.au/our-waste-challenges",Image="../Images/LinksImages/CleanUpLogo.jpg"}
            };
            links.ForEach(i => context.Links.AddOrUpdate(i));
            context.SaveChanges();

            var projects = new List<Project>
            {
            new Project{
                Name="Plastic Free Party",
                Description="Help protect the planet while having a good time!  Why not make your next party plastic free? ",
                LinkUrl="https://www.natgeokids.com/au/kids-club/cool-kids/general-kids-club/throw-a-plastic-free-party/",
                Image="../Images/ProjectImages/plastic_Free_party_1.jpeg"},
            new Project{
                Name="Rubbish Audit",
                Description="Do you know what you are throwing away? And where is this place \"away\"? Take a closer look and see if you can make greener choices ",
                LinkUrl="https://sustainableinthesuburbs.com/2021/04/23/how-to-conduct-a-trash-audit-with-kids/",
                Image="../Images/ProjectImages/Audit_IMG_4785-1030x772.jpeg"},
            new Project{
                Name="Build a Food Garden",
                Description="Growing your own food is even more satisfying when you recognise the plastic packaging avoided",
                LinkUrl="https://www.bunnings.com.au/diy-advice/garden/planting-and-growing/gardening-for-kids",
                Image="../Images/ProjectImages/grow-where-you-are-community-food-garden.jpg"},
            new Project{
                Name="Make plastic free food wrap",
                Description="Make you own environmentally friendly, reusable food wrap",
                LinkUrl="https://www.theplasticfreeshop.com.au/2019/06/06/diy-beeswax-foodwraps/\r\n",
                Image="../Images/ProjectImages/Foodwraps_med_strawberries-scaled-721x487.jpg"},
            new Project{
                Name="Save a Beach",
                Description="\"Small acts add up\".  Every piece of plastic you remove from a beach is one more prevented from entering our oceans ",
                LinkUrl="https://www.4ocean.com/blogs/blog/how-to-organize-a-community-beach-cleanup",
                Image="../Images/ProjectImages/istockphoto-1023573774-612x612.jpg"},

            };
            projects.ForEach(i => context.Projects.AddOrUpdate(i));
            context.SaveChanges();


            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/Dictionary.csv");
            var reader = new StreamReader(path);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var dictionary = csv.GetRecords<DictionaryWord>();
            dictionary.ForEach(i => context.Dictionary.AddOrUpdate(i));
            context.SaveChanges();

            //path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/Products.csv");
            //reader = new StreamReader(path);
            //csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            //var products = csv.GetRecords<Product>();
            //products.ForEach(i => context.Products.AddOrUpdate(i));
            //context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/alternatives.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var alternatives = csv.GetRecords<PlasticAlternative>();
            alternatives.ForEach(i => context.Alternatives.AddOrUpdate(i));
            context.SaveChanges();


        }


    }
}