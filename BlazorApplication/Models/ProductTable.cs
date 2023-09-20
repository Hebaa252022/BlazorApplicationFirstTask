using System;
using System.Collections.Generic;

namespace BlazorApplication.Models
{
    public partial class ProductTable
    {
        public ProductTable()
        {
            CustomerTables = new HashSet<CustomerTable>();
        }

        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? ProQuantity { get; set; }
        public int? ProPrice { get; set; }
        public string? ProColor { get; set; }

        public virtual ICollection<CustomerTable> CustomerTables { get; set; }
    }
}
