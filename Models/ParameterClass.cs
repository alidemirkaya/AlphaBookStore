using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Models
{
    public class ParameterClass
    {
        public string  ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Mail { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? finishDate { get; set; }
        public decimal StartPrice { get; set; }
        public decimal FinishPrice { get; set; }
        public bool inactiveCustomer { get; set; }
        public bool activeCustomer { get; set; }
    }
}