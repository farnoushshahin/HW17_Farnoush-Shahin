using HW17_Farnoush_Shahin.DAL;
using HW17_Farnoush_Shahin.Entities;

namespace HW17_Farnoush_Shahin.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public int Create(Student student)
        {
            return _repository.Create(student);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Edit(int id, string firstName, string lastName, int StdCardNumber)
        {
            _repository.Edit(id, firstName, lastName, StdCardNumber);
        }

        public List<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Student? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public List<Course> GetAllCoursesOfStudent(int stdId)
        {
            return _repository.GetAllCoursesOfStudent(stdId);
        }
        public List<Teacher> GetAllTeacherOfStudent(int stdId)
        {
            return _repository.GetAllTeacherOfStudent(stdId);
        }
    }
}
