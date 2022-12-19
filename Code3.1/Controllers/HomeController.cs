using Code3._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Code3._1.Controllers
{
   public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext db;
        
        public HomeController(ILogger<HomeController> logger,AppDBContext appDBContext)
        {
            _logger = logger;
            db = appDBContext;
           
        }


        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult studataList()
        {
            try
            {

                var data = db.students.ToList();
                return Json(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
            
        }
        [HttpPost]
        public IActionResult Addstu(Student stu)
        {
            try
            {
                //var emp = new Student();
                db.students.Add(stu);
                db.SaveChanges();
                return Json(stu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public IActionResult Delete(int studentid)
        {
            var data = db.students.Where(x => x.studentId == studentid).FirstOrDefault();
            db.students.Remove(data);
            db.SaveChanges();

            return Json("data delete");
        }
        public IActionResult Edit(int studentid)
        {

            var data = db.students.Where(x => x.studentId == studentid).FirstOrDefault();


            return Json(data);
        }
        [HttpPost]
        public IActionResult Update(Student stu)
            {
            db.students.Update(stu);
            db.SaveChanges();
            return Json("record update");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
