using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UwbItContest.Web.Features.Account
{
    public class Create
    {
        public class Command : IRequest
        {
            [Display(Name = "Adres email")]
            public string Email { get; set; }
            [Display(Name = "Hasło")]
            public string Password { get; set; }
            [Display(Name = "Hasło ponownie")]
            public string AgainPassword { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Password).Length(6, 15).NotEmpty();
                RuleFor(c => c.AgainPassword).Equal(c => c.Password).NotEmpty();
                RuleFor(c => c.Email).EmailAddress().NotEmpty();
            }
        }

        public class CommandHandler : RequestHandler<Command>
        {
            protected override void HandleCore(Command message)
            {
            }
        }
    }
} 