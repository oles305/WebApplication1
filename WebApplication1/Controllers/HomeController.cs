using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers.Users;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Models.Provider.IDataProvider dataProvider = new Models.Provider.EntityDataProvider();
               
        public List<User> Users { get; set; }

        public ActionResult Index(string n)
        {
            //Users = dataProvider.Users.ToList();
                                   
            return View(Users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }

}