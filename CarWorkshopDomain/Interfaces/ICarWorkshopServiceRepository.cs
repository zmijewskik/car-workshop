using CarWorkshopDomain.Entities;

namespace CarWorkshopDomain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task Create(CarWorkshopService carWorkshopService);
        Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName);
    }
}