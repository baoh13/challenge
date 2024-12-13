using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace challenge_features.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse>
        (ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TResponse: notnull
        where TRequest : notnull, IRequest<TResponse>
    {

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            logger.LogInformation($"[START] Handle request={typeof(TRequest).Name} - Response={typeof(TResponse).Name}", request);

            var timer = new Stopwatch();
            timer.Start();


            var response = await next();

            timer.Stop();
            var timeTaken = timer.Elapsed;

            if (timeTaken.Seconds > 2)
            {
                logger.LogWarning($"[PERFORMANCE] The request {typeof(TRequest).Name} took {timeTaken} secs", request, response);
            }

            logger.LogInformation($"[END] Handle request={typeof(TRequest).Name} - Response={typeof(TResponse).Name}", request, response);

            return response;
        }
    }
}
