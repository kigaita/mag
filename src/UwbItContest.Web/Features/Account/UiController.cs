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

        public ActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login.Command command)
        {
            var result = mediator.Send(command);
            

            return RedirectToAction("Index", "Home");
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