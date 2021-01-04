using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confectionery.DAL.Repositories
{
    class ProductsRepository : IProductsRepository
    {
        readonly ConfectioneryDbContext context;
        public ProductsRepository(ConfectioneryDbContext context) => this.context = context;
        public async Task<ICollection<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }
        public void DeleteCategory(Category c)
        {
            context.Categories.Remove(c);
        }
        public async Task<ICollection<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<ICollection<Product>> GetProducts(Category category)
        {
            return await context.Products.Where(p => p.CategoryId == category.Id).ToListAsync();
        }
        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateProduct(int id, KeyValuePair<string, object>[] properties)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);

            if(product != null)
            {
                foreach(var property in properties)
                { 
                    context.Products.Update(product).Property(property.Key).CurrentValue = property.Value;
                }
            }
        }
        public void DeleteProduct(Product p)
        {
            context.Products.Remove(p);
        }
    }
}
