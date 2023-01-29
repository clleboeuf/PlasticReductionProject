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

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/links.csv");
            var reader = new StreamReader(path);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var links = csv.GetRecords<Link>();
            links.ForEach(i => context.Links.AddOrUpdate(i));
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/projects.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var projects = csv.GetRecords<Project>();
            projects.ForEach(i => context.Projects.AddOrUpdate(i));
            context.SaveChanges();


            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/Dictionary.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var dictionary = csv.GetRecords<DictionaryWord>();
            dictionary.ForEach(i => context.Dictionary.AddOrUpdate(i));
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/products.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var products = csv.GetRecords<Product>();
            products.ForEach(i => context.Products.AddOrUpdate(i));
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/alternatives.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var alternatives = csv.GetRecords<PlasticAlternative>();
            alternatives.ForEach(i => context.Alternatives.AddOrUpdate(i));
            context.SaveChanges();


        }


    }
}