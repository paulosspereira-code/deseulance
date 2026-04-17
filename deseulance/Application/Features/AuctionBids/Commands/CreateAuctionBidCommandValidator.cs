using Application.Common.Interfaces.Services;
using FluentValidation;

namespace Application.Features.AuctionBids.Commands
{
    public class CreateAuctionBidCommandValidator : AbstractValidator<CreateAuctionBidCommand>
    {
        public CreateAuctionBidCommandValidator(
            IAuctionService auctionService,
            ILotService lotService,
            IAuctionBidService auctionBidService)
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

            RuleFor(x => x.BidAmount)
                        .NotEmpty().WithMessage("O valor do lance é obrigatório.")
                        .GreaterThan(0).WithMessage("O valor do lance deve ser maior que zero.")
                        .MustAsync(async (command, amount, ct) =>
                        {
                            var lot = await lotService.GetByIdAsync(command.LotId, ct);

                            if (lot == null) return false;

                            return amount >= lot.Price;
                        })
                        .WithMessage("O valor do lance é inferior ao preço mínimo do lote.");

            RuleFor(x => x.BidAmount)
                .CustomAsync(async (bidAmount, context, ct) =>
                {
                    var maiorLanceAtual = await auctionBidService.GetMaxBidAmountByLotIdAsync(context.InstanceToValidate.LotId, ct);
                    decimal valorMinimo;

                    if (maiorLanceAtual == 0)
                    {
                        var lot = await lotService.GetByIdAsync(context.InstanceToValidate.LotId, ct);
                        valorMinimo = lot?.Price ?? 0;
                    }
                    else
                    {
                        valorMinimo = maiorLanceAtual + 50;
                    }

                    if (bidAmount < valorMinimo)
                    {
                        context.AddFailure("BidAmount", $"O valor do lance é insuficiente. O próximo lance mínimo é {valorMinimo:C2}.");
                    }

                    var winner = await auctionBidService.GetWinnerAsync(context.InstanceToValidate.LotId, context.InstanceToValidate.AuctionId, ct);

                    if (winner != null && winner.UserClientId == context.InstanceToValidate.UserClientId)
                    {
                        context.AddFailure("UserClientId", "O seu último lance já é o vencedor atual deste lote.");
                        return;
                    }
                });

        }
    }
}
