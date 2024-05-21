using AppDemo.Domain;
using AppDemo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Azure.Infrastructure.Repositories
{
    internal class StudentRepository : IStudentRepository<Student, string>
    {
        public Student GetById(string entityId)
        {
            var idStudent = entityId.ToString();
            var student = new Student();

            switch (idStudent)
            {
                case "1751633578":
                    student.banner_id = "1751633578";
                    student.nombre_completo = "Victor Hernández";
                    student.correo_usfq = "victor@usf.com";
                    break;
                case "1752233578":
                    student.banner_id = "1752233578";
                    student.nombre_completo = "Andrea Fernandéz";
                    student.correo_usfq = "andrea@usf.com";
                    break;

                case "1750033578":
                    student.banner_id = "1750033578";
                    student.nombre_completo = "Lucía Gonzáles";
                    student.correo_usfq = "luc@usf.com";
                    break;
                case "1759993578":
                    student.banner_id = "1759993578";
                    student.nombre_completo = "Juan Ramiréz";
                    student.correo_usfq = "juan@usf.com";
                    break;
                default:
                    student = null;
                    break;
            }

            return student;
        }
    }
}
