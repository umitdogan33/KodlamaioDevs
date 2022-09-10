
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authentication
{
    public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IAuthRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) throw new AuthenticationException("you are not Authentication");

            TResponse response = await next();
            return response;
        }
    }
}
