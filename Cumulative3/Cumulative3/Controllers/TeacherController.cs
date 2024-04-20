using Cumulative3.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative3.Models;

namespace Cumulative3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //GET : /Teacher/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherFname, string teacherLname, string employeenumber, DateTime hiredate, decimal salary)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method!");
            Debug.WriteLine(teacherFname);
            Debug.WriteLine(teacherLname);
            Debug.WriteLine(employeenumber);
            Debug.WriteLine(hiredate);
            Debug.WriteLine(salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TfName = teacherFname;
            NewTeacher.TlName = teacherLname;
            NewTeacher.Tnumber = employeenumber;
            NewTeacher.Thiredate = hiredate;
            NewTeacher.Tsalary = salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }


        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" Page. Gathers information from the database.
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher/Update/5</example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        public ActionResult Ajax_Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }


        /// <summary>
        /// Receives a POST request containing information about an existing Teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="id">Id of the Author to update</param>
        /// <param name="teacherFname">The updated first name of the author</param>
        /// <param name="teacherLname">The updated last name of the author</param>
        /// <param name="employeenumber">The updated employee number of the author.</param>
        /// <param name="hiredate">The updated date tacher was hired.</param>
        /// <param name="salary">The updated date tacher was hired.</param>
        /// <returns>A dynamic webpage which provides the current information of the author.</returns>
        /// <example>
        /// POST : /Author/Update/10
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"AuthorFname":"Christine",
        ///	"AuthorLname":"Bittle",
        ///	"AuthorBio":"Loves Coding!",
        ///	"AuthorEmail":"christine@test.ca"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string teacherFname, string teacherLname, string employeenumber, DateTime hiredate, decimal salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TfName = teacherFname;
            TeacherInfo.TlName = teacherLname;
            TeacherInfo.Tnumber = employeenumber;
            TeacherInfo.Thiredate = hiredate;
            TeacherInfo.Tsalary = salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }

    }
}
