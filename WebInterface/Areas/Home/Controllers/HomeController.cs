using System.Web.Mvc;

namespace WebInterface.Areas.Home.Controllers
{
	[RouteArea("Home")]
	public class HomeController : Controller
	{
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[Authorize]
		public ActionResult Dashboard()
		{
			return View();
		}
	}
}