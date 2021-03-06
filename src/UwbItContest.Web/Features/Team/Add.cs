﻿using System.ComponentModel.DataAnnotations;
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
            [Display(Name = "Czy użytkownicy mogą dodawać się bez twojej zgody?")]
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
            protected override void HandleCore(Command message)
            {
                
            }
        }
    }
}