using StudentInquiryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInquiryApp.Controllers
{
    public class InquiryController : Controller
    {
        private StudentsDBEntities _db = new StudentsDBEntities();
        // GET: Inquiry
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Inquiry/Details/5
        public ActionResult Details(int id)
        {
            var studentToView = (from m in _db.Students
                                where m.Id == id
                                select m).First();
            return View(studentToView);
        }

        // GET: Inquiry/Create
        public ActionResult Create()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "Spokane Community College",
                Value = "SCC"
            });
            listItems.Add(new SelectListItem
            {
                Text = "Spokane Falls Community College",
                Value = "SFCC",
            });
            var model = new Student();
            model.Colleges = listItems;
            return View(model);
        }

        // POST: Inquiry/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Student studentToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            _db.Students.Add(studentToCreate);
            _db.SaveChanges();
            return RedirectToAction("Details/" + studentToCreate.Id);
        }

        // GET: Inquiry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inquiry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquiry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inquiry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
