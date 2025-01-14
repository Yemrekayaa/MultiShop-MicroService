using System;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetList;

public class GetOrderDetailListQuery : IRequest<List<GetOrderDetailListResponse>>
{
    public class GetOrderDetailListQueryHandler : IRequestHandler<GetOrderDetailListQuery, List<GetOrderDetailListResponse>>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailListQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailListResponse>> Handle(GetOrderDetailListQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderDetailListResponse>>(values);
        }
    }
}
