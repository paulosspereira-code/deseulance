using Application.Common.Interfaces.Services;
using FluentValidation;

namespace Application.Features.Auctions.Commands
{
    public class UpdateAuctionCommandValidator : AbstractValidator<UpdateAuctionCommand>
    {
        public UpdateAuctionCommandValidator(IAuctionService auctionService)
        {
            RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("O ID do leilão é obrigatório.")
            .MustAsync(async (id, ct) => await auctionService.CheckExist(id, ct))
            .WithMessage("Leilão não encontrado na base de dados.");
        }
    }
}