using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Infrastructure.Ports.Output.Repositories
{
    public interface IAsyncEntityRepository<TEntity>
    {
        Task<TEntity> GetById(string entity);
    }
}
