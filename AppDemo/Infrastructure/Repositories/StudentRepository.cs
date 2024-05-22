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
using Mailjet.Client;
using Newtonsoft.Json.Linq;
using Mailjet.Client.Resources;

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

        public async Task<string> SendEmail(string email)
        {
            string from = "jonathanquishpecatagna@gmail.com";
            try
            {
                MailjetClient client = new("af7a7ee43af4ba95c1a465fe32c379f5", "bfa231299331e14c850fbf67c61b2b60");
                MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                }
                 .Property(Send.Messages, new JArray {
                 new JObject {
                     {"To","Juan Perez"},
                     {"Subject","Correo enviado desde bus."},
                     {"Text-part","Correo de prueba"},
                     {"Html-part", "<h3>Correo enviado desde bus</h3><br />Mucho gusto!"},
                     {"CustomID","AppGettingStartedTest"},
                     {"FromEmail", from},
                     {"FromName", "Nexti"},
                     {
                         "Recipients",
                         new JArray {
                             new JObject {
                                 {"Email", email},
                                 {"Name", "andres"}
                             }
                         }
                     }
                 }
                 });

                MailjetResponse response = await client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return "Correo enviado";
                }


                throw new InvalidOperationException(response.GetErrorMessage());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
