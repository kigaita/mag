using System;
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
                RuleFor(c => c.Password).Matches(c => c.AgainPassword);
                RuleFor(c => c.AgainPassword).Matches(c => c.Password);
                RuleFor(c => c.Email).EmailAddress();
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