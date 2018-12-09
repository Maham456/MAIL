using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmailSetupController : Controller
    {
        public static string startTime;
        public static string endTime;

        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index3(WebApplication3.Models.gmail model)
        {
            MailMessage mm = new MailMessage("maham.asif456@gmail.com", "maham.asif456@gmail.com");//model.To ki jagah patient i

            mm.Subject = "APPOINTMENT STATUS";
            model.Subject = mm.Subject;
            mm.Body = "Your request has been accepted" + ". "+ "You need to come to the hospital at time"+""+ model.startTime +" " + "to"+ model.endTime;
            model.Body = mm.Body;

            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            NetworkCredential nc = new NetworkCredential("maham.asif456@gmail.com","maham180598");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully";
            return View();
        }
    }
}