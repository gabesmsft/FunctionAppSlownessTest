using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppSlownessTest
{
    public class Slow20minuteHttpFunction
    {
        private readonly ILogger _logger;

        public Slow20minuteHttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Slow20minuteHttpFunction>();
        }

        [Function("Slow20minuteHttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Slow20minuteHttpFunction processed a request.");

            Thread.Sleep(1200000);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("Welcome to Azure Functions!");

            //_logger.LogInformation("Slow20minuteHttpFunction execution completed.");

            return response;
        }
    }
}
