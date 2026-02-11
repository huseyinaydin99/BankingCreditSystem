using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Services;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest Request { get; set; } = default!;

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IApplicationUserRepository applicationUserRepository,
            IPasswordHashingService passwordHashingService,
            IMapper mapper,
            IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _applicationUserRepository = applicationUserRepository;
            _passwordHashingService = passwordHashingService;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand command, CancellationToken cancellationToken)
        {
            // ==================== BUSINESS RULES ====================
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(command.Request.NationalId);

            // ==================== 1. CREATE INDIVIDUAL CUSTOMER ====================
            var individualCustomer = _mapper.Map<IndividualCustomer>(command.Request);
            var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer, cancellationToken);

            // ==================== 2. CREATE APPLICATION USER ====================
            _passwordHashingService.CreatePasswordHash(command.Request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var applicationUser = new ApplicationUser<Guid>
            {
                Id = Guid.NewGuid(),
                Email = command.Request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                CustomerId = createdCustomer.Id,
                PhoneNumber = command.Request.PhoneNumber,
                Address = command.Request.Address,
                IsUserActive = true,
                OperationClaims = new List<string>()
            };

            await _applicationUserRepository.AddAsync(applicationUser, cancellationToken);

            // ==================== RESPONSE ====================
            var response = _mapper.Map<CreatedIndividualCustomerResponse>(createdCustomer);
            response.Message = IndividualCustomerMessages.CustomerCreated;
            
            return response;
        }
    }
}