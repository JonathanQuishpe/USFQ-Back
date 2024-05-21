using AppDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Aplications.Interfaces
{
    internal interface IStudentService<TEntity, TEntityId>: IStudent<TEntity, TEntityId>
    {

    }
}
