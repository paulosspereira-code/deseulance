
using FluentValidation;

namespace Application.Features.Auctions.Commands
{
    public class CreateAuctionCommandValidator : AbstractValidator<CreateAuctionCommand>
    {
        public CreateAuctionCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("O título não pode estar vazio.");

            RuleFor(x => x.AuctionDate)
            .NotNull().WithMessage("A data do leilão é obrigatória.")
            .NotEmpty().WithMessage("A data do leilão não pode estar vazia.")
            .Must(date => date > DateTime.Now).WithMessage("A data deve ser futura.");

            RuleFor(p => p.Lots)
                .NotEmpty().WithMessage("A lista de lotes não pode estar vazia.");
        }
    }
}
