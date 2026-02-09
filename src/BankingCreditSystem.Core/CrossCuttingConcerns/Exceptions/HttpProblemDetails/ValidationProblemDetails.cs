using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; init; }

        public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
        {
            Title = "Doðrulama hatasý(larý)";
            Detail = "Bir veya daha fazla doðrulama hatasý oluþtu.";
            Errors = errors;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://www.github.com/huseyinaydin99";
        }
    }
} 