using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class CreateUserCommandHandler(
        IUserService userService,
        IValidator<CreateUserCommand> validator) : IRequestHandler<CreateUserCommand, Unit>
    {

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var user = new UserClient(request.Name, request.Email, request.Password);

            await userService.AddAsync(user, cancellationToken);

            await userService.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }


}
