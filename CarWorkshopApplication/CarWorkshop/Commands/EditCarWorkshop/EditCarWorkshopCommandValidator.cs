using CarWorkshopApplication.CarWorkshop.Commands.CreateCarWorkshop;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopApplication.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
