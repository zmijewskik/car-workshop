using MediatR;

namespace CarWorkshopApplication.CarWorkshopService.Queries.GetCarWorkshopServices
{
    public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
