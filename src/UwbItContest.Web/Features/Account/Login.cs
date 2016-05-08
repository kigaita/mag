using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UwbItContest.Web.Features.Account
{
    public class Login
    {
        public class Command : IRequest<bool>
        {
            [Display(Name = "Adres email")]
            public string Email { get; set; }
            [Display(Name = "Hasło")]
            public string Password { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Password).Length(6, 15).NotEmpty();
                RuleFor(c => c.Email).EmailAddress().NotEmpty();
            }
        }

        public class CommandHandler : IRequestHandler<Command, bool>
        {
            public bool Handle(Command message)
            {
                return true;
            }
        }
    }
} 