using System;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList;

public class GetOrderingListQuery : IRequest<List<GetOrderingListResponse>>
{
    public class GetOrderingListQueryHandler : IRequestHandler<GetOrderingListQuery, List<GetOrderingListResponse>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderingListQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingListResponse>> Handle(GetOrderingListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderingListResponse>>(values);
        }
    }
}
