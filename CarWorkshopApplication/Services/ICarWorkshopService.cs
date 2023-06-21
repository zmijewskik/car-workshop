using CarWorkshopApplication.CarWorkshop;

namespace CarWorkshopApplication.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}