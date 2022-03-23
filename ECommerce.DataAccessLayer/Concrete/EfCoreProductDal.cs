using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.DatabaseContext;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product>, IProductDal
    {
        private readonly DataContext _context = new DataContext();
        public int Create(Product entity, int[] categorieIds)
        {
            entity.ProductsAndCategories = categorieIds.Select(c => new ProductAndCategory()
            {
                CategoryId = c,
                ProductId = entity.Id
            }).ToList();
            _context.Products.Add(entity);
            return _context.SaveChanges();
        }

        public Product GetCategoriesWithProductId(int id)
        {
            return _context.Products
                     .Where(x => x.Id == id)
                     .Include(x => x.ProductsAndCategories)
                     .ThenInclude(x => x.Category)
                     .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetail(int id)
        {
            return _context.Products
                        .Where(x => x.Id == id)
                        .Include(x => x.ProductsAndCategories)
                        .ThenInclude(x => x.Category)
                        .FirstOrDefault();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public int Update(Product entity, int[] categorieIds)
        {
            var product = _context.Products
                    .Where(x => x.Id == entity.Id)
                    .Include(x => x.ProductsAndCategories)
                    .FirstOrDefault();
            if (product != null)
            {
                product.Name = entity.Name;
                product.Image = entity.Image;
                product.Amount = entity.Amount;
                product.IsStock = entity.IsStock;
                product.Description = entity.Description;
                product.Price = entity.Price;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedUsername = "wbaran";
                product.ProductsAndCategories = categorieIds.Select(c => new ProductAndCategory()
                {
                    CategoryId = c,
                    ProductId = entity.Id
                }).ToList();
            }
            return _context.SaveChanges();
        }
    }
}
