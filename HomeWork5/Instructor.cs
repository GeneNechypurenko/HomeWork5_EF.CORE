namespace HomeWork5
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {InstructorId})";
        }
    }
}
