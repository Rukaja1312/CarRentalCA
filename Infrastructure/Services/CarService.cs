namespace Infrastructure.Services
{
    using Application.DTOs;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using Infrastructure.Persistence;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class CarService
    {


        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ICarCommands carCommands;

        public CarService(ApplicationDbContext context,
            IMapper mapper,
           ICarCommands carCommands)
        {
            this.context = context;
            this.mapper = mapper;
            this.carCommands = carCommands;
        }

        public async Task<bool> Create(CarCreateDTO carCreateDTO)
        {
            bool car = await carCommands.CarCreate(carCreateDTO);
            if (!car)
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await carCommands.Delete(id);
            if (result)
            {
                return false;
            }
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Car> DeleteGetById(int id)
        {
            return await carCommands.DeleteGet(id);
        }

        public async Task<CarEditDTO> Edit(int id)
        {
            return await carCommands.Edit(id);
        }

        public async Task<bool> Edit(int id, CarEditDTO carEditDTO)
        {
            var car = await carCommands.Edit(id, carEditDTO);

            if (car != null)
            {
                return false;
            }
            context.Update(car);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarViewDTO>> SearchByBrand(int? id)
        {
            return await carCommands.SearchByBrand(id);
        }

        public async Task<SelectList> BrandList()
        {
            return await carCommands.BrandList();
        }
    }
}


