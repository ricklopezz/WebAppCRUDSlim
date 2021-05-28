using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppCRUDSlim.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de Exámen para Fundación Carlos Slim";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Información";

            return View();
        }
    }
}