using HW17_Farnoush_Shahin.Services;
using Microsoft.AspNetCore.Mvc;

namespace HW17_Farnoush_Shahin.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService service)
        {
            _teacherService = service;
        }
        public IActionResult Index()
        {
            return View(_teacherService.GetAll());
        }
        public IActionResult ShowCourses(int Id)
        {
            return View(_teacherService.GetAllCoursesOfTeacher(Id));
        }
    }
}
