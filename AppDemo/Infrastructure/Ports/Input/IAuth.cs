using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDemo.Domain;

namespace AppDemo.Infrastructure.Ports.Input
{
    public interface IAuth
    {
        Task<Auth> GetAuth();
    }
}
