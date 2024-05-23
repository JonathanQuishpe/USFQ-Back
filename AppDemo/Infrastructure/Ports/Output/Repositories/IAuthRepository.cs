using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDemo.Domain;
using AppDemo.Infrastructure.Ports.Input;

namespace AppDemo.Infrastructure.Ports.Output.Repositories
{
    public interface IAuthRepository<TEntity>
    {
        Task<TEntity> GetAuth();
    }
}
