using AppDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Aplications.Interfaces
{
    internal interface IAuthService<TEntity>: IAuth<TEntity>
    {
    }
}
