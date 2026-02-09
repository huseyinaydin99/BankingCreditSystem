using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Ýþ kuralý ihlali";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://www.github.com/huseyinaydin99";
    }
} 