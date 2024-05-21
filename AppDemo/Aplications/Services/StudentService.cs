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
    public class StudentService : IStudentService<Student, String>
    {

        private readonly IStudentRepository<Student, String> _studentRepository;

        public StudentService(IStudentRepository<Student, String> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student GetById(string entityId)
        {
            return this._studentRepository.GetById(entityId);
        }
    }
}
