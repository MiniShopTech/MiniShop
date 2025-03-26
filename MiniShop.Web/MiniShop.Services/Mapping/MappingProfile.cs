using AutoMapper;
using MiniShop.DTOs.Requests;
using MiniShop.DTOs.Responses;
using MiniShop.DTOs;
using MiniShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap();
        }

        public void CreateMap()
        {
            CreateMap<Tenant, TenantDTO>().ReverseMap();

            #region Entity - Request
            CreateMap<Category, CategoryRequest>().ReverseMap();
            CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Variant, VariantRequest>().ReverseMap();
            CreateMap<Cart, CartRequest>().ReverseMap();
            CreateMap<Invoice, InvoiceRequest>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailRequest>().ReverseMap();
            CreateMap<Review, ReviewRequest>().ReverseMap();
            CreateMap<Staff, StaffRequest>().ReverseMap();
            #endregion

            #region Entity - Response
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Variant, VariantResponse>().ReverseMap();
            CreateMap<Cart, CartResponse>().ReverseMap();
            CreateMap<Invoice, InvoiceResponse>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailResponse>().ReverseMap();
            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<Staff, StaffResponse>().ReverseMap();
            #endregion

            #region Request - Response
            CreateMap<CategoryRequest, CategoryResponse>().ReverseMap();
            CreateMap<ProductRequest, ProductResponse>().ReverseMap();
            CreateMap<VariantRequest, VariantResponse>().ReverseMap();
            CreateMap<CartRequest, CartResponse>().ReverseMap();
            CreateMap<InvoiceRequest, InvoiceResponse>().ReverseMap();
            CreateMap<InvoiceDetailRequest, InvoiceDetailResponse>().ReverseMap();
            CreateMap<ReviewRequest, ReviewResponse>().ReverseMap();
            CreateMap<StaffRequest, StaffResponse>().ReverseMap();
            #endregion
        }
    }
}
