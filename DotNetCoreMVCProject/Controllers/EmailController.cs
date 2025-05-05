using DotNetCoreMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace DotNetCoreMVCProject.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            MdlEmail mdl = new MdlEmail();
            return View(mdl);
        }

        [HttpPost]
        public IActionResult Index(MdlEmail mdl)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(mdl.senderEmail!),
                Subject = mdl.subject,
                Body = mdl.body,
                IsBodyHtml = false
            };

            SmtpClient smtpClient = new SmtpClient(mdl.smtpServer, mdl.smtpPort)
            {
                Credentials = new NetworkCredential(mdl.senderEmail, mdl.senderPassword),
                EnableSsl = true
            };

            smtpClient.Send(mailMessage);
            return View("index");
        }
    }
}
