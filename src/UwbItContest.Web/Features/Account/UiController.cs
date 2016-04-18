using MediatR;
using System.Web.Mvc;

namespace UwbItContest.Web.Features.Account
{
    public class UiController : Controller
    {
        readonly IMediator mediator;

        public UiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Create.Command command)
        {
            mediator.Send(command);

            return RedirectToAction("Index", "Home");
        }
    }
}