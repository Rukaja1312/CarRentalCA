namespace Application.Commands
{
    using Application.DTOs;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using System.Web.Mvc;

    public class CarCommands : ICarCommands
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly HttpContextAccessor httpContextAccessor;

        public CarCommands(IApplicationDbContext context,
            IMapper mapper,
            HttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> CarCreate(CarCreateDTO carCreateDTO)
        {
            byte[] image = null;

            var carOutFile = mapper.Map<CarCreateOutOfIFormFileDTO>(carCreateDTO);
            var car = mapper.Map<Car>(carOutFile);

            if (carCreateDTO.Image != null)
            {
                using (MemoryStream mStream = new())
                {
                    carCreateDTO.Image.CopyTo(mStream);
                    image = mStream.ToArray();
                }
                car.Image = image;
            }

            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var brand = await context.SearchByBrands.Where(x => x.Id == car.BrandId).FirstOrDefaultAsync();
            var dealerId = await context.Dealers.Where(x => x.UserId == userId).Select(x => x.Id).FirstOrDefaultAsync();

            car.DealerId = dealerId;
            car.Brand = brand;

            Dealer d = context.Dealers.Where(x => x.Id == dealerId).FirstOrDefault();

            if (d == null)
            {
                return false;
            }

            await this.context.Cars.AddAsync(car);
            // await this.context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Car> DeleteGet(int id)
        {
            var car = await context.Cars.FindAsync(id);
            return car;
        }

        public async Task<bool> Delete(int id)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Car car = await context.Cars.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (car == null)
            {
                return false;
            }

            context.Cars.Remove(car);
            //await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarViewDTO>> GetAllCars()
        {
            var allCar = await context.Cars.Include(x => x.Brand).ToListAsync();
            var carView = mapper.Map<List<CarViewDTO>>(allCar);
            return carView;
        }

        public async Task<Car> Edit(int carId, CarEditDTO carEditDTO)
        {
            var carData = await this.context.Cars.Where(x => x.Id == carId).FirstOrDefaultAsync();

            Car car = mapper.Map<CarEditDTO, Car>(carEditDTO, carData);

            return car;
        }

        public async Task<CarEditDTO> Edit(int id)
        {
            var car = await this.context.Cars.FindAsync(id);
            var carEdit = mapper.Map<CarEditDTO>(car);
            return carEdit;
        }

        public async Task<List<CarViewDTO>> SearchByBrand(int? id)
        {
            var sortedCar = await context.Cars.Include(x => x.Brand).Where(x => x.BrandId == id).ToListAsync();

            var cars = mapper.Map<List<CarViewDTO>>(sortedCar);

            return cars;
        }

        public async Task<SelectList> BrandList()
        {
            var list = await context.SearchByBrands.OrderBy(x => x.Name).ToListAsync();
            return new SelectList(list, "Id", "Name");
        }

    }
}
