using System;
using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetList;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Profiles;

public class OrderingProfile : Profile
{
    public OrderingProfile()
    {
        CreateMap<Ordering, GetOrderingListResponse>().ReverseMap();
        CreateMap<Ordering, GetOrderingByIdResponse>().ReverseMap();
        CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
        CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
    }
}
