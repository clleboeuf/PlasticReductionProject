using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public enum FrequencySelection { Never, Sometimes, Often, Always }

    public enum TimePeriodSelection {Day = 1, Week = 2, Month = 3, Year = 4}

    public class ProductResult
    {
        public int Id { get; set; }

        public FrequencySelection Usage { get; set; }

        [Required]
        public  TimePeriodSelection?  PeriodUsed { get; set; } 

        public TimePeriodSelection PeriodRecycled { get; set; }

        public int AmountUsed { get; set; }

        public int AmountRecycled { get; set; }

        public Product Product { get; set; }

    }

}