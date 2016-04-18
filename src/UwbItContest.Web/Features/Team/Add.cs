using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;

namespace UwbItContest.Web.Features.Team
{
    public class Add
    {
        public class Command : IRequest
        {
            [Display(Name = "Nazwa drużyny")]
            public string TeamName { get; set; }
            [Display(Name = "Czy użytkownicy mogą dodawać się bez zgody?")]
            public bool CanAddTeamMembersImmidiately { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.TeamName).NotEmpty().Length(5, 10);
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