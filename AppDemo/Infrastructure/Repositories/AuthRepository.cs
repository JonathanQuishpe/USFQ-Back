using AppDemo.Domain;
using AppDemo.Domain.Interfaces;
using AppDemo.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Infrastructure.Repositories
{

 
    public class AuthRepository : IAuthRepository
    {

        string apiUrl = "https://wsidentity.usfq.edu.ec/ApiAuthentication/connect/token";

        public async Task<Auth> GetAuth()
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var formData = new MultipartFormDataContent();

                    formData.Add(new StringContent("testnexti_s32j0@!sdf56"), "client_id");
                    formData.Add(new StringContent("ewrfu6-trksa32-ghh673edd-dfg-fe4567ds"), "client_secret");
                    formData.Add(new StringContent("client_credentials"), "grant_type");

                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, formData);

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Auth auth = JsonConvert.DeserializeObject<Auth>(apiResponse);
                        return auth;
                    }

                    throw new InvalidOperationException("Error");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(ex.Message);
                }

            }
        }

    }
}
