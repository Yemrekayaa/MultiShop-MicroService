using System;
using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetById;

public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdResponse>
{
    public int Id { get; set; }

    public GetOrderDetailByIdQuery(int id)
    {
        Id = id;
    }

    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdResponse>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailByIdResponse> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetOrderDetailByIdResponse>(value);
        }
    }
}
