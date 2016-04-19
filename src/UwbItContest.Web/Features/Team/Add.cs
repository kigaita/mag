using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using UwbItContest.Web.DAL;

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
                RuleFor(c => c.TeamName).Length(5, 10).NotEmpty();
            }
        }

        public class CommandHandler : RequestHandler<Command>
        {
            private readonly UwbContestContext _db;

            public CommandHandler(UwbContestContext db)
            {
                _db = db;
            }

            protected override void HandleCore(Command message)
            {
                _db.Teams.Add();
            }
        }
    }
}