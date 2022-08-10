using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.Common.Behaviors
{
    public class RequestPreProcessor<TRequest, TResponse> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<RequestPreProcessor<TRequest, TResponse>> _logger;

        public RequestPreProcessor(ILogger<RequestPreProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Handling {typeof(TRequest)} Request. ( check behavior of pre processing of handlers.  for test Zhale :) )");
            
        }
    }
}
