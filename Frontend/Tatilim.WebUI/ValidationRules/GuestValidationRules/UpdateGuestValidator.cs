using FluentValidation;
using Tatilim.WebUI.Dtos.GuestDto;

namespace Tatilim.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Boş Geçilemez");
        }
    }
}
