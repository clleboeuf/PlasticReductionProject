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
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        // server path to image as a string so it can be stored in database
        public string LinkUrl { get; set; }

        public string Image { get; set; }



        //public virtual Uri Url
        //{
        //    get
        //    {
        //        if (this.LinkUrl != null)
        //        {
        //            return new Uri(this.LinkUrl);
        //        }
        //        return null;
        //    }

        //}
    }
}