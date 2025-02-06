using Microsoft.EntityFrameworkCore;
using PAW.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace PAW.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Products GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}