using System.Linq;
using AutoMapper;
using ProductShop.DTO.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, UserSoldProductDTO>()
                .ForMember(x => x.BuyerFirstName,
                    y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName,
                    y => y.MapFrom(x => x.Buyer.LastName));

            this.CreateMap<User, UserWithSoldProductsDTO>()
                .ForMember(x => x.SoldProducts,
                    y => y.MapFrom(x => x.ProductsSold.Where(p => p.Buyer != null)));

        }
    }
}
