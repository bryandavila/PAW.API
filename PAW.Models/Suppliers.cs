using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.Principal;

namespace PAW.Models
{
    public class Suppliers
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}