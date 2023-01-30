using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public enum FrequencySelection { Never, Sometimes, Often, Always }

    public enum TimePeriodSelection { Day, Week, Month, Year }

    public class ProductResults
    {
        public int Id { get; set; }

        public int AmountUsed { get; set; }

        public int AmountRecycled { get; set; }
    }

}