using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Domain.Interfaces
{
    public interface IAuth
    {
        Task<string> GetToken();
    }
}
