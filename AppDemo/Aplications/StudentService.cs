using AppDemo.Domain;
using AppDemo.Infrastructure.Ports.Input;
using AppDemo.Infrastructure.Ports.Output.Repositories;
using System.Threading.Tasks;

namespace AppDemo.Aplications
{
    public class StudentService : IStudent
    {

        private readonly IBaseRepository _studentRepository;

        public StudentService(IBaseRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<Student> GetById(string entityId)
        {
            return _studentRepository.GetById(entityId);
        }

        public Task<string> SendEmail(string email)
        {
            return _studentRepository.SendEmail(email);
        }
    }
}
