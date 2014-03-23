using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "GoodMorning" : "Good Afternoon";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebMail.SmtpServer = "smtp.sina.com";
                    WebMail.SmtpPort = 587;
                    WebMail.EnableSsl = true;
                    WebMail.UserName = "godseraph_mvc";
                    WebMail.Password = "mvc12345678";
                    WebMail.From = "godseraph_mvc@sina.com";
                    ServicePointManager.ServerCertificateValidationCallback = delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
                    WebMail.Send(guestResponse.Email, "RSVP Notification", guestResponse.Name + " is " + ((guestResponse.WillAttend ?? false) ? "" : "not") + "attending");
                    ViewBag.SendState = true;
                }
                catch(Exception e)
                {
                    ViewBag.SendState = false;
                    ViewBag.SendErrorMsg = e.Message;
                }

                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
	}
}