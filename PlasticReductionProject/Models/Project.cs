using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public class Project
    {
        [Key]
        [Name("Project_Id")]
        public int Id { get; set; }
        [Name("ProjectName")]
        public string Name { get; set; }
        [Name("ProjectDescription")]
        public string Description { get; set; }
        // server path to image as a string so it can be stored in database
        [Name("ProjectLink")]
        public string LinkUrl { get; set; }
        [Name("ProjectImage")]
        public string Image { get; set; }
    }
}