using System.Net.Http;
using System.Web.Mvc;

namespace Z2data.Web.APIs.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            ViewBag.Title = "Home Page";

            return "Z2data APIs is running ...";
        }
    }
}
