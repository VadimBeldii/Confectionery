﻿using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Confectionery.DAL.Repositories
{
    class ProductsRepository : IProductsRepository
    {
        readonly ConfectioneryDbContext context;
        public ProductsRepository(ConfectioneryDbContext context) => this.context = context;
        public void DeleteCategory(Category c)
        {
            context.Categories.Remove(c);
        }

        public void DeleteProduct(Product p)
        {
            context.Products.Remove(p);
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }
    }
}
