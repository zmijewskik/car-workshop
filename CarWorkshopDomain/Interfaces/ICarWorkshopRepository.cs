namespace CarWorkshopDomain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(CarWorkshopDomain.Entities.CarWorkshop carWorkshop);
        Task<CarWorkshopDomain.Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<CarWorkshopDomain.Entities.CarWorkshop>> GetAll();
        Task<CarWorkshopDomain.Entities.CarWorkshop> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
