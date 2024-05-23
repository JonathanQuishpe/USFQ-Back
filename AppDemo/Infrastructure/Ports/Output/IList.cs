using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Infrastructure.Ports.Output
{
    public interface IList<TEntity, TEntityId>
    {
        List<TEntity> List(TEntityId entity);
    }
}
