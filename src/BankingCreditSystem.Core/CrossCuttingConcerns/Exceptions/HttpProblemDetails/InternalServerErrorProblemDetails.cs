using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class InternalServerErrorProblemDetails : ProblemDetails
{
    public InternalServerErrorProblemDetails(string detail)
    {
        Title = "Ýç Sunucu Hatasý";
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "https://www.github.com/huseyinaydin99";
    }
} 