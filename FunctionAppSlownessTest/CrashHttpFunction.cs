using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppSlownessTest
{
    public class CrashHttpFunction
    {
        private readonly ILogger _logger;

        public CrashHttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CrashHttpFunction>();
        }

        [Function("CrashHttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("CrashHttpFunction processed a request.");

            int i = 1;
            int j = 0;

            int k = i / j;

            _logger.LogInformation("1 divided by 0 equals: " + k);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("Welcome to Azure Functions!");

            return response;
        }
    }
}
