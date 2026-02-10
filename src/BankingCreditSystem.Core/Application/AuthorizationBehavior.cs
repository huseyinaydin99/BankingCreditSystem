using MediatR;
using Microsoft.AspNetCore.Http;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Constants;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Extensions;

namespace BankingCreditSystem.Core.Application;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoleClaims == null)
            throw new AuthorizationException("Kimliğiniz henüz doğrulanmadı ki adamı dellendirme!");

        bool isNotMatchedAUserRoleClaimWithRequestRoles = string.IsNullOrEmpty(
            userRoleClaims.FirstOrDefault(
                userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaim)
            )
        );
        /*userRoleClaims
        .FirstOrDefault(
            userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaim)
        )
        .IsNullOrEmpty();*/
        if (isNotMatchedAUserRoleClaimWithRequestRoles)
            throw new AuthorizationException("Senin yetkin yok ki adamı dellendirme!");

        TResponse response = await next();
        return response;
    }
}
