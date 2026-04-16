using Application.Common.Interfaces.Services;
using Application.Services;
using FluentValidation;

namespace Application.Features.AuctionBids.Commands
{
    public class CreateAuctionBidCommandValidator : AbstractValidator<CreateAuctionBidCommand>
    {
        public CreateAuctionBidCommandValidator(IAuctionService auctionService, ILotService lotService)
        {
            RuleFor(x => x.AuctionBidDate)
            .NotNull().WithMessage("A data do lance é obrigatória.")
            .NotEmpty().WithMessage("A data do lance não pode estar vazia.");

            RuleFor(x => x.AuctionId)
            .GreaterThan(0).WithMessage("O ID do leilão é obrigatório.");

            RuleFor(x => x.LotId)
            .GreaterThan(0).WithMessage("O ID do lote é obrigatório.");

            RuleFor(x => x.UserClientId)
            .GreaterThan(0).WithMessage("O ID do usuário é obrigatório.");

            RuleFor(x => x.AuctionId)
              .MustAsync(async (auctionId, ct) => !await auctionService.CheckFinish(auctionId, ct))
              .WithMessage("O leilão informado já foi encerrado.");

            RuleFor(x => x.LotId)
              .MustAsync(async (lotId, ct) => !await lotService.CheckDeactivate(lotId, ct))
              .WithMessage("O lote informado já foi desativado.");

        }
    }
}
