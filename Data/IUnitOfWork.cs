﻿using System.Threading.Tasks;
using Confectionery.DAL.Repositories;

namespace Confectionery.DAL
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        IProductsRepository Products { get; }

        Task SaveAsync();
    }
}
