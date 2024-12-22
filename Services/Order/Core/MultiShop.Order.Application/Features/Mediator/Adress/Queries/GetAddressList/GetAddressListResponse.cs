using System;

namespace MultiShop.Order.Application.Features.Mediator.Adress.Queries.GetAddressList;

public class GetAddressListResponse
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Detail { get; set; }
}
