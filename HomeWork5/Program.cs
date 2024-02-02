using Microsoft.EntityFrameworkCore;

namespace HomeWork5
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //1
            using (var db = new UniversityDbContext())
            {
                var studentsOnCourse = db.Enrollments
                    .Where(enrollment => enrollment.CourseId == 3)
                    .Select(enrollment => enrollment.Student)
                    .ToList();

                foreach (var student in studentsOnCourse)
                    Console.WriteLine(student);
            }
            Console.WriteLine("-----------------------------------------------");

            //2
            using (var db = new UniversityDbContext())
            {
                var coursesTaughtByInstructor = db.Courses
                    .Where(course => course.InstructorId == 2)
                    .ToList();

                foreach (var course in coursesTaughtByInstructor)
                    Console.WriteLine(course);
            }
            Console.WriteLine("-----------------------------------------------");

            //3
            using (var db = new UniversityDbContext())
            {
                var coursesAndStudentsByInstructor = db.Courses
                    .Where(course => course.InstructorId == 2)
                    .Select(course => new
                    {
                        Course = course,
                        Students = course.Enrollments.Select(enrollment => enrollment.Student)
                    })
                    .ToList();

                foreach (var item in coursesAndStudentsByInstructor)
                {
                    Console.WriteLine($"Course: {item.Course}");
                    foreach (var student in item.Students)
                        Console.WriteLine($"  Student: {student}");
                }
            }
            Console.WriteLine("-----------------------------------------------");

            //4
            using (var db = new UniversityDbContext())
            {
                var coursesWithMoreThan10Students = db.Courses
                    .Where(course => course.Enrollments.Count > 10)
                    .ToList();

                foreach (var course in coursesWithMoreThan10Students)
                    Console.WriteLine(course);
            }
            Console.WriteLine("-----------------------------------------------");

            //5
            using (var db = new UniversityDbContext())
            {
                var studentsOlderThan25 = db.Students
                    .Where(student => DateTime.Now.Year - student.DateOfBirth.Year > 25)
                    .ToList();

                foreach (var student in studentsOlderThan25)
                    Console.WriteLine(student);
            }
            Console.WriteLine("-----------------------------------------------");

            //6
            using (var db = new UniversityDbContext())
            {
                var averageAge = db.Students
                    .Select(student => DateTime.Now.Year - student.DateOfBirth.Year)
                    .Average();

                Console.WriteLine($"Average Age of Students: {averageAge}");
                Console.WriteLine("-----------------------------------------------");
            }

            //7
            using (var db = new UniversityDbContext())
            {
                var youngestStudent = db.Students
                    .OrderBy(student => student.DateOfBirth)
                    .FirstOrDefault();

                Console.WriteLine($"Youngest Student: {youngestStudent}");
                Console.WriteLine("-----------------------------------------------");
            }

            //9
            using (var db = new UniversityDbContext())
            {
                var courseCount = db.Enrollments
                    .Where(enrollment => enrollment.StudentId == 4)
                    .Select(enrollment => enrollment.Course)
                    .Distinct()
                    .Count();

                Console.WriteLine($"Number of Courses for Student with ID {4}: {courseCount}");
                Console.WriteLine("-----------------------------------------------");
            }

            //10
            using (var db = new UniversityDbContext())
            {
                var studentNames = db.Students
                    .Select(student => $"{student.FirstName} {student.LastName}")
                    .ToList();

                foreach (var name in studentNames)
                    Console.WriteLine(name);

                Console.WriteLine("-----------------------------------------------");
            }

            //11
            using (var db = new UniversityDbContext())
            {
                var studentsByAgeGroup = db.Students
                    .GroupBy(student => DateTime.Now.Year - student.DateOfBirth.Year)
                    .Select(group => new
                    {
                        Age = group.Key,
                        Students = group.ToList()
                    })
                    .ToList();

                foreach (var ageGroup in studentsByAgeGroup)
                {
                    Console.WriteLine($"Age: {ageGroup.Age}");
                    foreach (var student in ageGroup.Students)
                        Console.WriteLine($"    {student}");
                }

                Console.WriteLine("-----------------------------------------------");
            }

            //12
            using (var db = new UniversityDbContext())
            {
                var studentsSortedByLastName = db.Students
                    .OrderBy(student => student.LastName)
                    .ToList();

                foreach (var student in studentsSortedByLastName)
                    Console.WriteLine(student);

                Console.WriteLine("-----------------------------------------------");
            }

            //13
            using (var db = new UniversityDbContext())
            {
                var studentsWithEnrollments = db.Students
                    .Include(student => student.Enrollments)
                    .ToList();

                foreach (var student in studentsWithEnrollments)
                {
                    Console.WriteLine(student);
                    foreach (var enrollment in student.Enrollments)
                        Console.WriteLine($"    {enrollment.Course}");
                }

                Console.WriteLine("-----------------------------------------------");
            }

            //14
            using (var db = new UniversityDbContext())
            {
                var studentsNotEnrolled = db.Students
                    .Where(student => !student.Enrollments.Any(enrollment => enrollment.CourseId == 3))
                    .ToList();

                foreach (var student in studentsNotEnrolled)
                    Console.WriteLine(student);

                Console.WriteLine("-----------------------------------------------");
            }

            //15
            using (var db = new UniversityDbContext())
            {
                var studentsEnrolledInBothCourses = db.Students
                    .Where(student =>
                        student.Enrollments.Any(enrollment => enrollment.CourseId == 4) &&
                        student.Enrollments.Any(enrollment => enrollment.CourseId == 2))
                    .ToList();

                foreach (var student in studentsEnrolledInBothCourses)
                    Console.WriteLine(student);

                Console.WriteLine("-----------------------------------------------");
            }

            //16
            using (var db = new UniversityDbContext())
            {
                var studentsCountByCourse = db.Courses
                    .Select(course => new
                    {
                        Course = course,
                        StudentsCount = course.Enrollments.Count
                    })
                    .ToList();

                foreach (var courseWithCount in studentsCountByCourse)
                {
                    Console.WriteLine($"{courseWithCount.Course}: Students Count - {courseWithCount.StudentsCount}");
                }

                Console.WriteLine("-----------------------------------------------");
            }


            //using (var db = new UniversityDbContext())
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    var student1 = new Student { FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1) };
            //    var student2 = new Student { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateOnly(1992, 5, 10) };
            //    var student3 = new Student { FirstName = "Robert", LastName = "Johnson", DateOfBirth = new DateOnly(1988, 8, 20) };
            //    var student4 = new Student { FirstName = "Emily", LastName = "Brown", DateOfBirth = new DateOnly(1995, 3, 15) };
            //    var student5 = new Student { FirstName = "Michael", LastName = "Jones", DateOfBirth = new DateOnly(1993, 7, 5) };
            //    db.Students.AddRange(student1, student2, student3, student4, student5);

            //    var instructor1 = new Instructor { FirstName = "Alex", LastName = "Smith" };
            //    var instructor2 = new Instructor { FirstName = "Jennifer", LastName = "Miller" };
            //    var instructor3 = new Instructor { FirstName = "Daniel", LastName = "Taylor" };
            //    var instructor4 = new Instructor { FirstName = "Sophia", LastName = "Clark" };
            //    var instructor5 = new Instructor { FirstName = "David", LastName = "Anderson" };
            //    db.Instructors.AddRange(instructor1, instructor2, instructor3, instructor4, instructor5);

            //    var course1 = new Course { Title = "Mathematics", Description = "Fundamentals of Mathematics", InstructorId = 1 };
            //    var course2 = new Course { Title = "History", Description = "World History", InstructorId = 2 };
            //    var course3 = new Course { Title = "Computer Science", Description = "Introduction to Programming", InstructorId = 3 };
            //    var course4 = new Course { Title = "Physics", Description = "Basic Physics Concepts", InstructorId = 4 };
            //    var course5 = new Course { Title = "Literature", Description = "Classic Literature", InstructorId = 5 };
            //    db.Courses.AddRange(course1, course2, course3, course4, course5);

            //    var enrollment1 = new Enrollment { Student = student1, Course = course1, EnrollmentDate = DateTime.Now.Date };
            //    var enrollment2 = new Enrollment { Student = student2, Course = course2, EnrollmentDate = DateTime.Now.Date };
            //    var enrollment3 = new Enrollment { Student = student3, Course = course3, EnrollmentDate = DateTime.Now.Date };
            //    var enrollment4 = new Enrollment { Student = student4, Course = course4, EnrollmentDate = DateTime.Now.Date };
            //    var enrollment5 = new Enrollment { Student = student5, Course = course5, EnrollmentDate = DateTime.Now.Date };
            //    db.Enrollments.AddRange(enrollment1, enrollment2, enrollment3, enrollment4, enrollment5);

            //    db.SaveChanges();
            //}
        }
    }
}