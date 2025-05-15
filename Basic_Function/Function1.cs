using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Basic_Function
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private object JsonConvert;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("HttpExample")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

           
            string responseMessage = string.IsNullOrEmpty(name)
                ? "Please pass a name in the query string or in the request body."
                : $"Hello, {name}! Your Azure Function executed successfully.";

            return new OkObjectResult(responseMessage);

        }
    }
}
