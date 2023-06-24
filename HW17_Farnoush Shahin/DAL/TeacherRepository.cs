using HW17_Farnoush_Shahin.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HW17_Farnoush_Shahin.DAL
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly HWAppContext _dbcontext;

        public TeacherRepository(HWAppContext context)
        {
            _dbcontext = context;
        }
        public List<Teacher> GetAll()
        {
            return _dbcontext.Teachers.ToList();
        }

        public List<Course> GetAllCoursesOfTeacher(int teacherId)
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                return _dbcontext.Teachers
                        .Where(x => x.Id == teacherId)
                        .Include(x => x.Courses)
                        .FirstOrDefault()
                        .Courses.ToList();
                var result =
                     (
                     from t in _dbcontext.Teachers
                     join c in _dbcontext.Courses on t.Id equals c.TeacherId
                     where t.Id==teacherId
                     select new Course
                     {
                         Id = c.Id,
                         Name=c.Name,
                         Unit = c.Unit
                     }).ToList();
                return result;
            }
            catch
            {
                return new List<Course>();
            }
            
        }

        public Teacher? GetById(int id)
        {
            return _dbcontext.Teachers.FirstOrDefault(x => x.Id == id);
        }
    }
}
