
namespace HomeWork5
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return $"{Title} (ID: {CourseId}, Description: {Description})";
        }
    }
}
