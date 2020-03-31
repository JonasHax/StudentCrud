using StudentCrud.Data;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCrud.Controllers {

    public class StudentController : Controller {

        // GET: Student
        public ActionResult Index() {
            var model = StudentData.StudentList;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id) { // Edit til GET
            Student editStudent = StudentData.GetStudentById((int)id);
            return View(editStudent);
        }

        [HttpPost]
        public ActionResult Edit(Student stu) { // Edit metode til POST
            var id = stu.StudentId;
            var name = stu.Studentname;
            var age = stu.Age;

            Student updated = new Student(id, name, age);
            // Update i "database"
            StudentData.UpdateStudent(updated);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id) {
            if (id != null && id > -1) {
                var model = StudentData.GetStudentById((int)id);
                if (model == null) {
                    return View("NotFound");
                }
                return View(model);
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student createdStudent) {
            if (ModelState.IsValid) {
                // tilføj til database
                StudentData.InsertStudent(createdStudent);
                return RedirectToAction("Details", new { id = createdStudent.StudentId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            var model = StudentData.GetStudentById((int)id);
            if (model == null) {
                return View("Not Found");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form) {
            // Delete from "Database"
            StudentData.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}