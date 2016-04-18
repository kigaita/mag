using System.Web.Mvc;

namespace UwbItContest.Web.Features.Team
{
    public class UiController : Controller
    {
        public ActionResult Add() => View();

        [HttpPost]
        public ActionResult Add(Add.Command command)
        {
            return RedirectToAction("Index", "User");
        }
    }
}