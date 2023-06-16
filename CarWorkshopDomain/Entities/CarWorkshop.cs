using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopDomain.Entities
{
    public class CarWorkshop
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public CarWorkshopContactDetails ContactDetails { get; set; } = default!;

        public string EncodedName { get; private set; } = default!;

        public void EncodeNam() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
