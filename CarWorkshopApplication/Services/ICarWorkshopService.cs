using CarWorkshopDomain.Entities;

namespace CarWorkshopApplication.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshop carWorkshop);
    }
}