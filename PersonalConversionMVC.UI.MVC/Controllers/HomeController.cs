using PersonalConversionMVC.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalConversionMVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            string body = $"You have received an email from <strong>{cvm.Name}</strong>. The email address given was <strong>{cvm.Email}</strong>.<br/><strong>The following message was sent:</strong>{cvm.Message}";

            MailMessage mm = new MailMessage("admin@edwardbarrier.com", "edwardbarrieriii@outlook.com", cvm.Subject, body);



            mm.IsBodyHtml = true;
            mm.ReplyToList.Add(cvm.Email);

            SmtpClient smtp = new SmtpClient("mail.edwardbarrier.com");

            smtp.Credentials = new NetworkCredential("admin@edwardbarrier.com", "Cam#Jay#71#");
            //smtp.UseDefaultCredentials = false;
            //smtp.Port = 25;
            //smtp.EnableSsl = false;
            smtp.Send(mm);
            return Json(cvm);
        }


        public PartialViewResult ContactConfirmation(string name, string email)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            return PartialView("ContactConfirmation");
        }
    }
}