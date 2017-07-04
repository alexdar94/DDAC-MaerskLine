using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static MaerskLineEntities4 db = new MaerskLineEntities4();
        
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult SetRole()
        {
            ViewBag.Role = db.MLUserRoles.Find(User.Identity.Name).Role;
            return PartialView("_RolePartial");
        }
    }
}