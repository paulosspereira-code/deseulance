using Application.Common.Interfaces.Services;
using Application.Features.Auctions.Commands;
using Application.Services;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {

        public CreateUserCommandValidator(IUserService userService)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome não pode estar vazio.");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("O email não pode estar vazio.")
                .EmailAddress().WithMessage("O email deve ser válido.");
            RuleFor(p => p.Password)
                 .NotEmpty().WithMessage("A senha não pode estar vazia.")
                 .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");
            RuleFor(x => x.Email)
                .MustAsync(async (email, ct) => !await userService.CheckExist(email, ct))
                .WithMessage("O email já está em uso.");
        }

    }
}
