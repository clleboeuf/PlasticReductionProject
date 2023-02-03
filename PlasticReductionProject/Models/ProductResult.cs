using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public enum FrequencySelection { Never, Sometimes, Often, Always }

    public enum TimePeriodSelection { Day, Week, Month, Year }

    public class ProductResult
    {
        public int Id { get; set; }

        public FrequencySelection Usage { get; set; }   

        public TimePeriodSelection PeriodUsed { get; set; } 

        public TimePeriodSelection PeriodRecycled { get; set; }

        public int AmountUsed { get; set; }

        public int AmountRecycled { get; set; }

        public Product Product { get; set; }

        /*public ProductResult(int _productId)
        {
            this.Id = _productId;
        }*/

    }

}