using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.VieModels;



namespace WebApplication1.Controllers.Users
{
    public class UsersController : Controller
    {
        Models.Provider.IDataProvider dataProvider = new Models.Provider.EntityDataProvider();
        
        // GET: Users
        public ActionResult Index(User user)
        {
            return View(User);
        }

        /*
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Pasword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Pasword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        
        // GET: Users/LogIn
        public ActionResult LogIn()
        {
            return View(User);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([Bind(Include = "Name,Pasword")] User user)
        {
            if (ModelState.IsValid)
            {
                if (dataProvider.CheckUser(user) == false)
                {
                    return View(user);
                }
                
                Session["login"] = user.Name;
                //Session.Timeout = 10;
                return RedirectToAction("ViewUser", "Users", user);
            }

            return View(user);
        }

        public ActionResult ViewUser(User user)
        {
            var viewUser = new ViewUser() { User = user };
            viewUser.Messages = dataProvider.GetViewMessages(10);
            viewUser.UsersNames = dataProvider.GetUsersNames(10);

            return View(viewUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewUser()
        {
            //var viewUser = new ViewUser(); { User = user};
            //foreach (var mes in dataProvider.GetViewMessages(10))
            //{
            //    viewUser.Messages.Add(mes);
            //}
            
            return View();
        }


        public ActionResult LogOut()
        {
            Session["login"] = null;//обнул сессионную переменную
            Session.Abandon();//завершение сесии
            
            return Redirect("/Home/Index");
        }

        
    }
}
