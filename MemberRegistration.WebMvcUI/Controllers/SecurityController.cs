using MemberRegistration.DataAccess.Concrete.EntityFramework;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MemberRegistration.WebMvcUI.Controllers
{

    //burdaki işlemler admin tarafın olacak başvuru listelerini falan görebilecek...


    public class SecurityController : Controller
    {

        MembershipContext db = new MembershipContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }




        [AllowAnonymous]
        public ActionResult Login2()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login2(User user)
        {
            var kullanici = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                //Session["UserName"] = user.UserName;
                return RedirectToAction("Anasayfa", "Member");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya şifre Yanlış!!!";
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            User userModel = new User();
            return View(userModel);

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(User userModel)
        {

            using (MembershipContext dbModel = new MembershipContext())
            {
                if (dbModel.Users.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.MessageRegister = "Kullanıcı zaten mevcut";
                    return View("Register", userModel);
                }

                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Kayıt Başarılı";
            return View("Register",new User());
        }
    }
}