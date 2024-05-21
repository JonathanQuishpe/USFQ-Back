using AppDemo.Aplications.Interfaces;
using AppDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Aplications.Services
{
    internal class AuthService : IAuthService<Auth>
    {
        public Auth GetToken()
        {
            throw new NotImplementedException();
        }
    }
}
