﻿using AutoMapper;
using CarWorkshopDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopApplication.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<CarWorkshopDomain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
