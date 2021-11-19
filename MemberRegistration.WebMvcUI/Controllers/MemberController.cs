using MemberRegistration.Business.Abstract;
using MemberRegistration.DataAccess.Concrete.EntityFramework;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.WebMvcUI.Filters;
using MemberRegistration.WebMvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace MemberRegistration.WebMvcUI.Controllers
{

    public class MemberController : Controller
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }



        [Authorize(Roles = "User")]
        public ActionResult Add()
        {
            MembershipContext db = new MembershipContext();
            List<SelectListItem> degerler = (from i in db.Recourses.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.RecourseType,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();

        }


        [HttpPost]
        [ExceptionHandler]
        public ActionResult Add(Member member)
        {
            _memberService.Add(member);
            ViewBag.Mesaj = "Başvuru Kaydedildi";
            return RedirectToAction("Add", "Member");
            //return View("Member", "Add");

        }





        [Authorize(Roles = "Admin")]
        public ActionResult GetList()
        {

            return View();
        }



        [HttpGet]
        public JsonResult GetJsonList()
        {
            var users = _memberService.GetRecourseList();
            MemberGetListViewModel model = new MemberGetListViewModel()
            {
                MemberForRecourseDtos = users
            };


            //Server side için parametreler
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];



            users = _memberService.GetRecourseList();
            int totalrows = users.Count;

            //Arama filtreleme
            if (!string.IsNullOrEmpty(searchValue))
            {
                users = users.Where(x => x.Name.ToLower().Contains(searchValue.ToLower())
                                        || x.Name.ToLower().Contains(searchValue.ToLower())
                                        || x.LastName.ToLower().Contains(searchValue.ToLower())
                                        || x.Email.ToString().Contains(searchValue.ToLower())
                                        || x.RecourseType.ToString().Contains(searchValue.ToLower())).ToList();
            }
            int totalrowsafterfiltering = users.Count;


            //Sayfalama
            users = users.Skip(start).Take(length).ToList();


            return Json(new
            {
                data = users,
                draw = Request["draw"],
                recordsTotal = totalrows,
                recordsFiltered = totalrowsafterfiltering
            }, JsonRequestBehavior.AllowGet);


        }



        public ActionResult Anasayfa()
        {

            return View();
        }

    }


}
