using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
namespace MemberRegistration.WebMvcUI.Controllers
{
    public class UserController : Controller
    {
        //private IUserService _userService;
        //private IMemberService _memberService;

        //public UserController(IUserService userService, IMemberService memberService)
        //{
        //    _userService = userService;
        //    _memberService = memberService;
        //}


        [Authorize(Roles = "Admin")]
        public ActionResult Mail()
        {
            return View();
        }


        [LogAspect(typeof(DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [HttpPost]
        public JsonResult GetJsonMail(SmtpSettings model)
        {
            MailMessage mm = new MailMessage("enessadikk@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("enessadikk@gmail.com", "Enes.gm3306");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Başarıyla Gönderildi...";

            return Json(model, JsonRequestBehavior.AllowGet);


        }

    }
}