using System;
using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Adress.Commands.Create;
using MultiShop.Order.Application.Features.Mediator.Adress.Commands.Update;
using MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressById;
using MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressList;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Adress.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, GetAddressListResponse>().ReverseMap();
        CreateMap<Address, GetAddressByIdResponse>().ReverseMap();
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
    }
}
