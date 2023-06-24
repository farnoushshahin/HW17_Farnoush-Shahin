using HW17_Farnoush_Shahin.Entities;

namespace HW17_Farnoush_Shahin.Services
{
    public interface IStudentService
    {
		public int Create(Student student);

		public void Edit(int id, string firstName, string lastName, int StdCardNumber);

		public void Delete(int id);

		public Student? GetById(int id);

		public List<Student> GetAll();
		public List<Course> GetAllCoursesOfStudent(int stdId);
		public List<Teacher> GetAllTeacherOfStudent(int stdId);
	}
}
