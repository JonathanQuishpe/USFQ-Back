using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDemo.Domain;

namespace AppDemo.Infrastructure.Ports.Input
{
    public interface IStudent
    {
        Task<Student> GetById(string entityId);
        Task<string> SendEmail(string email);
    }
}
