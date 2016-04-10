using MediatR;
using System.Web.Mvc;

namespace UwbItContest.Web.Features.Home
{
    public class UiController : Controller
    {
        private readonly IMediator _mediator;

        public UiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index() => View();
    }
}