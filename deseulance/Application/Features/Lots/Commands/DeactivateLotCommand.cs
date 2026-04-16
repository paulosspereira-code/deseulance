using Application.Common.Interfaces.Services;
using FluentValidation;
using MediatR;

namespace Application.Features.Lots.Commands
{
    public class DeactivateLotCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeactivateLotCommandHandler(
   ILotService lotService,
       IValidator<DeactivateLotCommand> validator) : IRequestHandler<DeactivateLotCommand, Unit>
    {
        public async Task<Unit> Handle(DeactivateLotCommand request, CancellationToken ct)
        {

            await validator.ValidateAndThrowAsync(request, ct);

            var lot = await lotService.GetByIdAsync(request.Id, ct);

            lot!.Deactivate();

            lotService.Update(lot);

            await lotService.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
