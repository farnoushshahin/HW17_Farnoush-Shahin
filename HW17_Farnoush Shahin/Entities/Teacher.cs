namespace HW17_Farnoush_Shahin.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<Course> Courses { get; set; }
    }
}
