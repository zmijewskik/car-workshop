using MediatR;

namespace CarWorkshopApplication.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommand : CarWorkshopServiceDto, IRequest
    {
        public string CarWorkshopEncodedName { get; set; } = default!;
    }
}
