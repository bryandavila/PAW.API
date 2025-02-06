using PAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Business
{
    public interface ISuppliersManager
    {
        IEnumerable<Suppliers> GetSuppliers();
    }

    public class SuppliersManager : ISuppliersManager
    {
        public IEnumerable<Suppliers> GetSuppliers()
        {
            var suppliers = new List<Suppliers>();
            for (var i = 0; i < 10; i++)
            {
                suppliers.Add(new Suppliers
                {
                    SupplierID = $"SUP-00{i}",
                    SupplierName = $"Supplier {i}",
                    ContactName = $"Contact {i}",
                    ContactTitle = $"Title {i}",
                    Phone = $"123-456-789{i}",
                    Address = $"Address {i}",
                    City = $"City {i}",
                    Country = $"Country {i}"
                });
            }

            return suppliers;
        }
    }
}
