namespace HW17_Farnoush_Shahin.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentCardNumber { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
