using System.Collections.Generic;
using System.Threading.Tasks;
using Confectionery.DAL.EF.Entities;

namespace Confectionery.DAL.Repositories
{
    public interface IProductsRepository
    {
        Task<ICollection<Product>> GetProducts();
        Task<ICollection<Product>> GetProducts(Category category);
        void DeleteProduct(Product p);
        Task<ICollection<Category>> GetCategories();
        void DeleteCategory(Category c);
    }
}
