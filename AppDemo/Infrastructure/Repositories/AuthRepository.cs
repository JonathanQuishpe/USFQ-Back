using AppDemo.Domain;
using AppDemo.Domain.Interfaces;
using AppDemo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository<Auth>
    {
        Auth IAuth<Auth>.GetToken()
        {
            throw new NotImplementedException();
        }
    }
}
