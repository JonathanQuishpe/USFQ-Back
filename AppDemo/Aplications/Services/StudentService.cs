using AppDemo.Aplications.Interfaces;
using AppDemo.Domain;
using AppDemo.Domain.Interfaces.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Azure.Aplications.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<Student> GetById(string entityId)
        {
            return this._studentRepository.GetById(entityId);
        }

        public Task<string> SendEmail(string email)
        {
            return this._studentRepository.SendEmail(email);
        }
    }
}
