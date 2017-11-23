using GenerationgOffers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenerationgOffers.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailService _emailService;
        public HomeController()
        {
            _emailService = new EmailService();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _emailService.ValidateEmail("das");
            return View();
        }
    }
}
