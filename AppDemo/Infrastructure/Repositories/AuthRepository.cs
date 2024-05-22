using AppDemo.Domain;
using AppDemo.Domain.Interfaces;
using AppDemo.Domain.Interfaces.Repositories;
using AppDemo.Infrastructure.MyAdapters.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public Task<string> GetToken()
        {
            AuthAdapterInput adapter = new AuthAdapterInput();
            return adapter.GetToken();
        }

    }
}
