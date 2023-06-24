using HW17_Farnoush_Shahin.Entities;
using HW17_Farnoush_Shahin.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17_Farnoush_Shahin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService istudentservice)
        {
            _studentService = istudentservice;
        }
        public IActionResult Index()
        {
            return View(_studentService.GetAll());
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int id,string firstName, string lastName, int StdCardNumber)
        {
            _studentService.Edit(id, firstName, lastName, StdCardNumber);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_studentService.GetById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentService.Create(student);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ShowCourses(int Id)
        {
            return View(_studentService.GetAllCoursesOfStudent(Id));
        }
        [HttpGet]
        public IActionResult ShowTeachers(int Id)
        {
            return View(_studentService.GetAllTeacherOfStudent(Id));
        }
    }
}
