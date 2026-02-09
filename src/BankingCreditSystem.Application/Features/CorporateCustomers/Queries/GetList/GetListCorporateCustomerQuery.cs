using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerQuery : IRequest<Paginate<CorporateCustomerResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, Paginate<CorporateCustomerResponse>>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCorporateCustomerQueryHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<CorporateCustomerResponse>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _corporateCustomerRepository.GetListAsync(
                index: request.PageIndex,
                size: request.PageSize,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<Paginate<CorporateCustomerResponse>>(customers);
            return response;
        }
    }
}