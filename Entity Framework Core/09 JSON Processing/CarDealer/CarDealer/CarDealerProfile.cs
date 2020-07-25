using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Customers;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, GetOrderedCustomersDTO>()
                .ForMember(x=>x.Name,
                    y=>y.MapFrom(x=>x.Name))
                .ForMember(x=>x.BirthDate,
                    y=>y.MapFrom(x=>x.BirthDate.ToString("dd/MM/yyyy")))
                .ForMember(x=>x.IsYoungDriver,
                    y=>y.MapFrom(x=>x.IsYoungDriver));
        
        }
    }
}
