using CarWorkshopDomain.Entities;
using CarWorkshopDomain.Interfaces;
using CarWorkshopInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopInfrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
            => _dbContext.SaveChangesAsync();

        public async Task Create(CarWorkshop carWorkshop)
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshop>> GetAll()
            => await _dbContext.CarWorkshops.ToListAsync();

        public async Task<CarWorkshop> GetByEncodedName(string encodedName)
            => await _dbContext.CarWorkshops.FirstAsync(x => x.EncodedName == encodedName);

        public Task<CarWorkshop?> GetByName(string name)
            => _dbContext.CarWorkshops.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
    }
}
