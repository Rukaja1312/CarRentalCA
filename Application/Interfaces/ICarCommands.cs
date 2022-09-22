namespace Application.Interfaces
{
    using Application.DTOs;
    using Domain.Entities;
    using System.Web.Mvc;

    public interface ICarCommands
    {
        Task<List<CarViewDTO>> GetAllCars();
        Task<bool> CarCreate(CarCreateDTO carCreateDTO);
        Task<bool> Delete(int id);
        Task<Car> DeleteGet(int id);
        Task<Car> Edit(int carId, CarEditDTO carEditDTO);
        Task<CarEditDTO> Edit(int id);
        Task<List<CarViewDTO>> SearchByBrand(int? id);
        Task<SelectList> BrandList();
    }
}
