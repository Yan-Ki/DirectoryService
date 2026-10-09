using DirectoryService.Contracts;
using DirectoryService.Contracts.Location;
using DirectoryService.Domain.Constants;
using FluentValidation;

namespace DirectoryService.Application.Locations;

public class CreateLocationDtoValidator:AbstractValidator<CreateLocationDto>
{
    public CreateLocationDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(LengthConstants.Length3)
            .MinimumLength(LengthConstants.Length150)
            .WithMessage("Имя невалидно");
        RuleFor(x => x.City).NotNull().NotEmpty();
        RuleFor(x => x.Street).NotNull().NotEmpty();
        RuleFor(x => x.House).NotNull().NotEmpty();
        RuleFor(x => x.Apartment).NotNull().NotEmpty();
    }
}