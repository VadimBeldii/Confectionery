using Confectionery.DAL.EF;
using Confectionery.DAL.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confectionery.DAL.Repositories
{
    class StatisticsRepository : IStatisticsRepository
    {
        readonly ConfectioneryDbContext context;
        public StatisticsRepository(ConfectioneryDbContext context) => this.context = context;
        public async Task<ICollection<Statistics>> GetStatistics()
        {
            return await context.Statistics.ToListAsync();
        }

        public void Add(Statistics statistics)
        {
            var s = context.Statistics.Find(statistics);
            if(s == default(Statistics))
            {
                context.Statistics.Add(statistics);
            }
            else
            {
                s.Purchased += statistics.Purchased;
                s.PurchasedSeparately += statistics.PurchasedSeparately;
            }
        }
    }
}
