using System;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressList;

public class GetAddressListQuery : IRequest<List<GetAddressListResponse>>
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<GetAddressListResponse>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressListQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressListResponse>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAddressListResponse>>(values);
        }
    }
}
