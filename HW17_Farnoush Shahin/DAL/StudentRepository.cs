using HW17_Farnoush_Shahin.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HW17_Farnoush_Shahin.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HWAppContext _dbcontext;

        public StudentRepository(HWAppContext context)
        {
            _dbcontext = context;
        }
        public int Create(Student student)
        {
            var id = _dbcontext.Students.Add(student).Entity.Id;
            _dbcontext.SaveChanges();
            return id;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbcontext.Students.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public void Edit(int id, string firstName, string lastName, int StdCardNumber)
        {
            var entity = GetById(id);
            entity.FirstName = firstName;
            entity.LastName = lastName;
            entity.StudentCardNumber = StdCardNumber;
            _dbcontext.Students.Update(entity);
            _dbcontext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _dbcontext.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _dbcontext.Students.FirstOrDefault(x => x.Id == id);
        }
        public List<Course> GetAllCoursesOfStudent(int stdId)
        {
            try 
            {

                var x = _dbcontext.Students.SingleOrDefault(s => s.Id == stdId).Courses.Select(s=>s.Name).ToList();
                  //  CourseStudents.Select(x=>x.Course).ToList();
                    
                

                //.Include(f => f.Courses).
                
                var result =
                    (
                        from c in _dbcontext.Courses
                        join cstd in _dbcontext.CourseStudents on c.Id equals cstd.CourseId
                        join s in _dbcontext.Students on cstd.StudentId equals s.Id
                        where s.Id == stdId
                        select new Course
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Unit = c.Id
                        }).ToList();
                return result;
            }
            catch
            {
                var courses = new List<Course>();
                return courses;
            }
               
                
        }
        public List<Teacher> GetAllTeacherOfStudent(int stdId)
        {
            try 
            {
                var result =
                     (
                     from s in _dbcontext.Students
                     join cstd in _dbcontext.CourseStudents on s.Id equals cstd.StudentId
                     join c in _dbcontext.Courses on cstd.CourseId equals c.Id
                     join t in _dbcontext.Teachers on c.TeacherId equals t.Id
                     where s.Id == stdId
                     select new Teacher
                     {
                         Id = t.Id,
                         Name = t.Name,
                         Department = t.Department
                     }
                     ).ToList();
                return result;


#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var x = _dbcontext.Students.Select(x => x.FirstName);
                var courses = _dbcontext.Students

                .Where(x => x.Id == stdId)
                .Include(x => x.Courses)
                .ThenInclude(c => c.Teacher)
                .FirstOrDefault().Courses.Select(x=>x.Teacher.Name)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                                ;
                //var result2 = from s in courses
                //             select s.Teacher;
                return result2.ToList();
            }
            catch
            {
                return new List<Teacher>();
            }
              
        }
    }
}
