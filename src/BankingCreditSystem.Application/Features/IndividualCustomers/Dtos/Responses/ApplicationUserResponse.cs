namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class ApplicationUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool IsUserActive { get; set; }
}
