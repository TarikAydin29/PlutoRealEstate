using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.CustomerArea.Controllers
{
	public class DefaultController : CustomerBaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
