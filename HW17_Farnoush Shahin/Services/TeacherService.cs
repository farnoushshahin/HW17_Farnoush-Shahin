using HW17_Farnoush_Shahin.DAL;
using HW17_Farnoush_Shahin.Entities;

namespace HW17_Farnoush_Shahin.Services
{
    public class TeacherService : ITeacherService
    {        
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {     
            _teacherRepository = teacherRepository;
        }
        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();           
        }

        public List<Course> GetAllCoursesOfTeacher(int teacherId)
        {
            return _teacherRepository.GetAllCoursesOfTeacher(teacherId);
        }

        public Teacher? GetById(int id)
        {
            return _teacherRepository.GetById(id);
        }
    }
}
