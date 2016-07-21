using CRMSystem.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMSystem.BLL.Repositories;

namespace CRMSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Repository repo;

        public HomeController() 
        {
            repo = new Repository();
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
