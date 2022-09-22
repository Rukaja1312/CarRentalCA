using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DealaerService
    {
        private readonly ApplicationDbContext context;
        private readonly Mapper mapper;
        private readonly IDealerCommands dealerCommands;

        public DealaerService(ApplicationDbContext context,
            Mapper mapper,
            IDealerCommands dealerCommands)
        {
            this.context = context;
            this.mapper = mapper;
            this.dealerCommands = dealerCommands;
        }
        public async Task<List<CarViewDTO>> DealerCars()
        {
            return await dealerCommands.DealerCars();
        }

        public async Task<bool> CreateDealer(DealerDTO dealerDTO)
        {
            var result = await dealerCommands.CreateDealer(dealerDTO);
            if (!result)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> IsDealer(string id)
        {
            return await dealerCommands.IsDealer(id);
        }
    }
}
