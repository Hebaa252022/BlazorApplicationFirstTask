using System;
using System.Collections.Generic;

namespace BlazorApplication.Models
{
    public partial class CustomerTable
    {
        public int CustomerID { get; set; }
        public string Cus_Name { get; set; }
        public int? Cus_Age { get; set; }
        public int? Cus_Product { get; set; }

        public virtual ProductTable Cus_ProductNavigation { get; set; }
        //public int ProductID { get; internal set; }
    }
}
