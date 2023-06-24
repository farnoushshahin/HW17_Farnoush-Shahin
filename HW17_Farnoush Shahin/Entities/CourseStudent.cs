namespace HW17_Farnoush_Shahin.Entities
{
    public class CourseStudent
    {        
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
