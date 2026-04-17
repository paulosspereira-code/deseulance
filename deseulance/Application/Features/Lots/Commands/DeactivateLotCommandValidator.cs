using FluentValidation;

namespace Application.Features.Lots.Commands
{
    public class DeactivateLotCommandValidator : AbstractValidator<DeactivateLotCommand>
    {
        public DeactivateLotCommandValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("O ID do lote é obrigatório.");
        }
    }
}
