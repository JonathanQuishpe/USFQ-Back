using AppDemo.Aplications.Interfaces;
using AppDemo.Azure.Infrastructure.Repositories;
using AppDemo.Domain;
using AppDemo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Aplications.Services
{
    internal class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<string> GenerateTokenExternal()
        {
            return await _authRepository.GetToken();
        }
    }
}
