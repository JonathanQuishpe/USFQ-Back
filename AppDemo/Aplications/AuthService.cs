using AppDemo.Domain;
using AppDemo.Infrastructure.Ports.Input;
using AppDemo.Infrastructure.Ports.Output.Repositories;
using System.Threading.Tasks;

namespace AppDemo.Aplications
{
    public class AuthService : IAuth
    {

        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        public async Task<Auth> GetAuth()
        {
            return await _authRepository.GetAuth();
        }

    }
}
