using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THEtask.Models;

namespace THEtask.Controllers
{
    [Authorize ]
    public class Medical_ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medical_Profile
        public ActionResult Index()
        {

            var user = User.Identity.GetUserId();

            var querymd = from md in db.Medical_Profile 
                                       where md.User  == user
                                       select md;
            var querymd2 = from md2 in db.Medical_Profile
                          where md2.User == user
                          select md2.User;
            
            var check = db.Medical_Profile.Where(a => a.User == user).ToList();
            if (check.Count < 1 )
            {
                
               return RedirectToAction("Create");
            }
            else
            {
                return View(querymd);
            }
          
               
           
        
        }

    

        // GET: Medical_Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medical_Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Height,Goal_of_diet,Exercise_Time,Leve_of_Exercise,Daily_Food,Vitamins,Problem_History,User")] Medical_Profile medical_Profile)
        {
            if (ModelState.IsValid)
            {
                medical_Profile.User = User.Identity.GetUserId();
                db.Medical_Profile.Add(medical_Profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medical_Profile);
        }

        // GET: Medical_Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Profile medical_Profile = db.Medical_Profile.Find(id);
            if (medical_Profile == null)
            {
                return HttpNotFound();
            }
            return View(medical_Profile);
        }

        // POST: Medical_Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Height,Goal_of_diet,Exercise_Time,Leve_of_Exercise,Daily_Food,Vitamins,Problem_History,User")] Medical_Profile medical_Profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_Profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medical_Profile);
        }

        // GET: Medical_Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Profile medical_Profile = db.Medical_Profile.Find(id);
            if (medical_Profile == null)
            {
                return HttpNotFound();
            }
            return View(medical_Profile);
        }

        // POST: Medical_Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medical_Profile medical_Profile = db.Medical_Profile.Find(id);
            db.Medical_Profile.Remove(medical_Profile);
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
    }
}
