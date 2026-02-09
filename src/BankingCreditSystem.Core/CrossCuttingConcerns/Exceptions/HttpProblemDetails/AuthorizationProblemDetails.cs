using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class AuthorizationProblemDetails : ProblemDetails
{
    public AuthorizationProblemDetails(string detail)
    {
        Title = "Yetkilendirme veya kimlik doðrulama hatasý";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://www.github.com/huseyinaydin99";
    }
} 