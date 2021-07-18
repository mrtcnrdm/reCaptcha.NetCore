using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using reCaptcha.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace reCaptcha.NetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.reCaptcha response)
        {
            Recaptcha();
            if (check)
            {
                //ok
                return View();
            }
            else
            {
                //error
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }
        }

        private bool check;

        public void Recaptcha()
        {
            var response = Request.Form["g-Recaptcha-Response"];
            string secretKey = "secret-key";
            var client = new WebClient();
            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));

            var captchaResponse = JsonConvert.DeserializeObject<Models.reCaptcha>(GoogleReply);
            if (captchaResponse.Success)

                check = true;
            else

                check = false;
        }
    }
}