using Confectionery.DAL.EF;
using Confectionery.DAL.Repositories;
using System.Threading.Tasks;
#nullable enable

namespace Confectionery.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConfectioneryDbContext context;
        private IOrderRepository? orders;
        private ICategoryRepository? categories;
        private IProductsRepository? products;
        private IStatisticsRepository? statistics;
        public UnitOfWork(ConfectioneryDbContext context) => this.context = context;
        public IOrderRepository Orders => orders ??= new OrderRepository(context);
        public ICategoryRepository Categories => categories ??= new CategoryRepository(context);
        public IProductsRepository Products => products ??= new ProductsRepository(context);
        public IStatisticsRepository Statistics => statistics ??= new StatisticsRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
