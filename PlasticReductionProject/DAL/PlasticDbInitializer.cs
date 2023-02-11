using CsvHelper;
using Microsoft.Ajax.Utilities;
using PlasticReductionProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PlasticReductionProject.DAL
{

    internal class PlasticDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<PlasticDbContext>  //  DropCreateDatabaseIfModelChanges<LinkDbContext>  or DropCreateDatabaseAlways<LinkDbContext>

    {
        protected override void Seed(PlasticDbContext context)
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
            products.ForEach(i =>
            {
                i.averageUtilisation = 0;
                context.Products.AddOrUpdate(i);
            });
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/alternatives.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var alternatives = csv.GetRecords<PlasticAlternative>();
            alternatives.ForEach(i => context.Alternatives.AddOrUpdate(i));
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/plastic_type.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var plastic_types = csv.GetRecords<PlasticType>();
            plastic_types.ForEach(pt =>
            {

                context.PlasticTypes.AddOrUpdate(pt);
                // Calculate average utilisation per product
                var productListOfType = context.Products.Where(prod => prod.Type == pt.Id).ToList();
       
                double productMassSumForPlasticType = productListOfType.Sum(prod => prod.Weight);
                productListOfType.ForEach(prod => prod.averageUtilisation = prod.Weight / productMassSumForPlasticType * pt.AnnualTarget);

            });
            context.SaveChanges();

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"./DAL/badges.csv");
            reader = new StreamReader(path);
            csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var badges = csv.GetRecords<Badge>();
            badges.ForEach(i => context.Badges.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}