using HW17_Farnoush_Shahin.Entities;

namespace HW17_Farnoush_Shahin.Services
{
    public interface ITeacherService
    {
        public Teacher? GetById(int id);

        public List<Teacher> GetAll();
        public List<Course> GetAllCoursesOfTeacher(int teacherId);
    }
}
