using AppDemo.Aplications.Services;
using AppDemo.Domain;
using AppDemo.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Azure.Infrastructure.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public async Task<Student> GetById(string entityId)
        {
            string apiUrl = "https://wsexternal.usfq.edu.ec/WSApisUSFQ-TEST/api/Estudiante/InfoEstudiante?banner_id=" + entityId;

            AuthService authService = new AuthService();
            var token = await authService.GenerateTokenExternal();
            using (HttpClient client = new())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        Student student = JsonConvert.DeserializeObject<Student>(jsonResponse);

                        return student;
                    }

                    throw new InvalidOperationException("Estudiante no existe");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }
            }
        }
    }
}
