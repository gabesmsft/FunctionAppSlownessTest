using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppSlownessTest
{
    public class Slow25MinuteHttpFunction
    {
        private readonly ILogger _logger;

        public Slow25MinuteHttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Slow25MinuteHttpFunction>();
        }

        [Function("Slow25MinuteHttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Slow25MinuteHttpFunction processed a request.");

            Thread.Sleep(1500000);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("Welcome to Azure Functions!");
			
			_logger.LogInformation("Slow25MinuteHttpFunction execution completed.");

            return response;
        }
    }
}
