using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;

using System.Collections.Generic;
using System.Linq;

namespace Confectionery.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ConfectioneryDbContext context;
        public CategoryRepository(ConfectioneryDbContext context) => this.context = context;

        public ICollection<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public void DeleteCategory(Category c)
        {
            context.Categories.Remove(c);
        }
    }
}
