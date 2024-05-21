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

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Funtion1/{banner_id}")] HttpRequest req,
            string banner_id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var student = getService().GetById(banner_id);

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            return new OkObjectResult(student);
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
