using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
