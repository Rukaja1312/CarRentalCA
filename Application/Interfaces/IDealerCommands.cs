using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDealerCommands
    {
        Task<List<CarViewDTO>> DealerCars();
        Task<bool> CreateDealer(DealerDTO dealerDTO);
        Task<bool> IsDealer(string id);
    }
}
