using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.Common.Behaviors
{
    public class RequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly ILogger<RequestPostProcessor<TRequest, TResponse>> _logger;

        public RequestPostProcessor(ILogger<RequestPostProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Handled {typeof(TRequest) } with Response. {typeof(TResponse)} this request was processed. ( check behavior of Post processing of handlers. for test Zhale :) )");
        }
    }

}
