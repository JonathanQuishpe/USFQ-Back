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
using AppDemo.Infrastructure.Repositories;

namespace AppDemo.Azure.Infrastructure.Repositories
{
    internal class StudentRepository : IStudentRepository
    {

        static AuthService getServiceAuth()
        {
            AuthRepository repo = new AuthRepository();
            return new AuthService(repo);
        }

        public async Task<Student> GetById(string entityId)
        {
            string apiUrl = "https://wsexternal.usfq.edu.ec/WSApisUSFQ-TEST/api/Estudiante/InfoEstudiante?banner_id=" + entityId;

            AuthService authService = getServiceAuth();
            var auth = await authService.GetAuth();
            var token = auth.access_token;

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
