﻿using CarWorkshopDomain.Entities;
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
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopServiceRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CarWorkshopService carWorkshopService)
        {
            _dbContext.Services.Add(carWorkshopService);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Services
            .Where(s => s.CarWorkshop.EncodedName == encodedName)
            .ToListAsync();
    }
}