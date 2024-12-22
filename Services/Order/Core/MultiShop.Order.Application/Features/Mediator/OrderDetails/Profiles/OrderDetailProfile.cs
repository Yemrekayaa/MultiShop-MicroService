using System;
using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetById;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetList;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Profiles;

public class OrderDetailProfile : Profile
{
    public OrderDetailProfile()
    {
        CreateMap<OrderDetail, GetOrderDetailByIdResponse>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailListResponse>().ReverseMap();
        CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
    }
}
