using FluentValidation;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.GuestDto;

namespace Tatilim.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator :AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Boş Geçilemez");
        }
    }
}
