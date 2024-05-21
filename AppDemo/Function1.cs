using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AppDemo.Azure.Aplications.Services;
using AppDemo.Azure.Infrastructure.Repositories;
using System.Runtime.CompilerServices;
using AppDemo.Aplications.Services;
using AppDemo.Domain;

namespace AppDemo.Azure
{
    public static class Function1
    {
        static StudentService getService()
        {
            StudentRepository repo = new StudentRepository();
            StudentService service = new StudentService(repo);
            return service;
        }

        static AuthService auth()
        {
            return new AuthService();
        }

        [FunctionName("GetStudent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Student/{banner_id}")] HttpRequest req,
            string banner_id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                var student = await getService().GetById(banner_id);
                var response = new
                {
                    data = student,
                    status = true
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    status = false,
                    message = ex.Message
                };

                return new OkObjectResult(response);
            }

        }

        [FunctionName("Function2")]
        public static async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Funtion2/{banner_id}")] HttpRequest req,
            string banner_id,
            ILogger log)
        {
            var message = "Bienvenido";
            return new OkObjectResult(message);
        }
    }
}
