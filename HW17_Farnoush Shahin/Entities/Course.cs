namespace HW17_Farnoush_Shahin.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
