using System.Threading.Tasks;
using Confectionery.DAL.Repositories;

namespace Confectionery.DAL
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        ICategoryRepository Categories { get; }
        IProductsRepository Products { get; }
        IStatisticsRepository Statistics { get; }

        void Save();
    }
}
