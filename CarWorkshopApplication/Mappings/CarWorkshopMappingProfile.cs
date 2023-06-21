using AutoMapper;
using CarWorkshopApplication.CarWorkshop;
using CarWorkshopApplication.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshopDomain.Entities;

namespace CarWorkshopApplication.Mappings
{
    public class CarWorkshopMappingProfile : Profile
    {
        public CarWorkshopMappingProfile()
        {
            CreateMap<CarWorkshopDto, CarWorkshopDomain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));
            CreateMap<CarWorkshopDomain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        }
    }
}
