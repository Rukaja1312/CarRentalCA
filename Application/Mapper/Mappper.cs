using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class Mappper : Profile
    {
        public Mappper()
        {
            CreateMap<CarCreateDTO, Car>();
            CreateMap<Car, CarViewDTO>();
            CreateMap<CarCreateOutOfIFormFileDTO, Car>();
            CreateMap<CarCreateDTO, CarCreateOutOfIFormFileDTO>();
            CreateMap<CarEditDTO, Car>();
            CreateMap<Car, CarEditDTO>();
            CreateMap<DealerCarsDTO, Car>();
            CreateMap<DealerDTO, Dealer>();
        }
    }
}
