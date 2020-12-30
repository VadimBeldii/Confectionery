using System.Collections.Generic;
using System.Threading.Tasks;
using Confectionery.DAL.EF.Entities;
namespace Confectionery.DAL.Repositories
{
    public interface IStatisticsRepository
    {
        Task<ICollection<Statistics>> GetStatistics();
    }
}
