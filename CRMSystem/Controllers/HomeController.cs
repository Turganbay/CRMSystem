using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Repository.Repository repo;

        public HomeController() 
        {
            repo = new Repository.Repository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return PartialView();
        }

        // view events with course
        public ActionResult Events()
        {
            return PartialView();
        }

        // login

        public JsonResult UserLogin(LoginData d) 
        {
            Users user = repo.getUser(d);

            return Json(user, JsonRequestBehavior.AllowGet);
        
        }

        public ActionResult Login() 
        {
            return PartialView();
        }

    }
}
