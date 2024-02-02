namespace HomeWork5
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public override string ToString()
            => $"{FirstName} {LastName} (ID: {StudentId}, Date of Birth: {DateOfBirth.ToShortDateString()})";
    }
}
