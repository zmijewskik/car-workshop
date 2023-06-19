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
    }
}
