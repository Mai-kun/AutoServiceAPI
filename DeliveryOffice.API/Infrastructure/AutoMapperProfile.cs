﻿using AutoMapper;
using DeliveryOffice.Core.Models;
using DeliveryOffice.Core.RequestModels;
using DeliveryOffice.Core.ResponseModels;

namespace DeliveryOffice.API.Infrastructure;

/// <inheritdoc />
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Supplier, SupplierResponse>()
            .ForMember(dest => dest.Bills, opt => opt.MapFrom(src => src.Bills.Select(b => b.Id)));
        CreateMap<CreateSupplierRequest, Supplier>().ReverseMap();
        CreateMap<SupplierRequest, Supplier>().ReverseMap();

        CreateMap<Product, ProductResponse>();
        CreateMap<CreateProductRequest, Product>().ReverseMap();
        CreateMap<ProductRequest, Product>().ReverseMap();
    }
}
