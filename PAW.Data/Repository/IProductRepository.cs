using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Models.Models;

namespace PAW.Data.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        IEnumerable<Products> GetAllProducts();
        Products GetById(int id);
        void Add(Products product);
        void Update(Products product);
        void Delete(int id);
    }
}
