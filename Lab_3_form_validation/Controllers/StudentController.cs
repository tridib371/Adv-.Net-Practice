using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_3_form_validation.Models;


namespace Lab_3_form_validation.Content
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }



        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid) {

                return RedirectToAction("Index", "Home");
            
            }
            return View(s);
        }
    }
}