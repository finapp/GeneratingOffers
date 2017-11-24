using GenerationgOffers.IServices;
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
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public ActionResult Index()
        {
            _emailService.ValidateEmail("das");
            return View();
        }
    }
}
