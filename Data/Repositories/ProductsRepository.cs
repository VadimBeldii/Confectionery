using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;

using System.Collections.Generic;
using System.Linq;

namespace Confectionery.DAL.Repositories
{
    class ProductsRepository : IProductsRepository
    {
        readonly ConfectioneryDbContext context;
        public ProductsRepository(ConfectioneryDbContext context) => this.context = context;

        public ICollection<Product> GetProducts()
        {
            return context.Products.ToList();
        }
        public ICollection<Product> GetProducts(Category category)
        {
            return context.Products.Where(p => p.CategoryId == category.Id).ToList();
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
