using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppSlownessTest
{
    public class Slow12minuteHttpFunction
    {
        private readonly ILogger _logger;

        public Slow12minuteHttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Slow12minuteHttpFunction>();
        }

        [Function("Slow12minuteHttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Slow12minuteHttpFunction processed a request.");

            Thread.Sleep(720000);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("Welcome to Azure Functions!");

            //_logger.LogInformation("Slow12minuteHttpFunction execution completed.");

            return response;
        }
    }
}
