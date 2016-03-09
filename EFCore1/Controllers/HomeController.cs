using EFCore1.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCore1.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var post = (from x in context.Posts
                        select x).ToList();

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
    }
}