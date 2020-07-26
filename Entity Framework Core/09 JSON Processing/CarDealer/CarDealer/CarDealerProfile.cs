using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customers;
using CarDealer.DTO.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, GetOrderedCustomersDTO>()
                .ForMember(x => x.Name,
                    y => y.MapFrom(x => x.Name))
                .ForMember(x => x.BirthDate,
                    y => y.MapFrom(x => x.BirthDate.ToString("dd/MM/yyyy")))
                .ForMember(x => x.IsYoungDriver,
                    y => y.MapFrom(x => x.IsYoungDriver));

            this.CreateMap<Car, GetCarsFromMakeToyotaDTO>()
                .ForMember(x => x.Id,
                    y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Make,
                    y => y.MapFrom(x => x.Make))
                .ForMember(x => x.Model,
                    y => y.MapFrom(x => x.Model))
                .ForMember(x => x.TravelledDistance,
                    y => y.MapFrom(x => x.TravelledDistance));

            this.CreateMap<ImportCarsDTO, Car>()
                .ForMember(x => x.Make,
                    y => y.MapFrom(x => x.Make))
                .ForMember(x => x.Model,
                    y => y.MapFrom(x => x.Model))
                .ForMember(x => x.TravelledDistance,
                    y => y.MapFrom(x => x.TravelledDistance))
                .ForMember(x => x.PartCars,
                    y => y.MapFrom(x => x.PartsId));

            this.CreateMap<Car, GetListOfCarsWithParts>()
                .ForMember(x=>x.Make,
                    y=>y.MapFrom(x=>x.Make))
                .ForMember(x=>x.Model,
                    y=>y.MapFrom(x=>x.Model))
                .ForMember(x=>x.TravelledDistance,
                    y=>y.MapFrom(x=>x.TravelledDistance))
                .ForMember(x=>x.Parts,
                    y=>y.MapFrom(x=>x.PartCars));

            this.CreateMap<Customer, CustomerCarDto>()
                .ForMember(x => x.FullName,
                    y => y.MapFrom(x => x.Name))
                .ForMember(x => x.BoughtCars,
                    y => y.MapFrom(x => x.Sales.Count))
                .ForMember(x => x.SpentMoney,
                    y => y.MapFrom(x => x.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));
        }
    }
}
