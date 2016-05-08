using System.Web.Mvc;
using MediatR;

namespace UwbItContest.Web.Features.Ajax
{
    public class UiController : Controller
    {
        private readonly IMediator _mediator;

        public UiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public JsonResult GetTeams() => Json(_mediator.Send(new GetTeams.Query()), JsonRequestBehavior.AllowGet);
    }
}