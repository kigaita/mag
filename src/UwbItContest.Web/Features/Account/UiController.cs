using System.Web.Mvc;

namespace UwbItContest.Web.Features.Account
{
    public class UiController : Controller
    {
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Create.Command command)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}