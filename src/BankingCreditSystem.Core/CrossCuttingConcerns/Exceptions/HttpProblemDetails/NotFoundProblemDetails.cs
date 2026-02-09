using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class NotFoundProblemDetails : ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Title = "Bulunamadý";
        Detail = detail;
        Status = StatusCodes.Status404NotFound;
        Type = "https://www.github.com/huseyinaydin99";
    }
} 