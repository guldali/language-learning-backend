using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Services
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int DurationInHours { get; set; }
        public string DifficultyLevel { get; set; }
        public List<User> EnrolledUsers { get; set; } = new List<User>();
    }

    public class CourseService
    {
        private readonly List<Course> _courses;

        public CourseService()
        {
            _courses = new List<Course>
            {
                new Course { Id = 1, Title = "Spanish for Beginners", Description = "An introductory course to learn Spanish.", Content = "Course content here", DurationInHours = 10, DifficultyLevel = "Beginner" },
                new Course { Id = 2, Title = "Advanced French", Description = "An advanced course to enhance your French skills.", Content = "Course content here", DurationInHours = 15, DifficultyLevel = "Intermediate" },
                new Course { Id = 3, Title = "Turkish for Beginners", Description = "An advanced course to enhance your Turkish skills.", Content = "Course content here", DurationInHours = 20, DifficultyLevel = "Beginner" },
                new Course { Id = 4, Title = "Turkish French", Description = "An advanced course to enhance your Turkish skills.", Content = "Course content here", DurationInHours = 25, DifficultyLevel = "Intermediate" },
            };
            // Dummy user enrollment for testing purposes
                        var user1 = new User { Id = 1, Email = "guldali@test.com" };
                        _courses[0].EnrolledUsers.Add(user1);
                        _courses[1].EnrolledUsers.Add(user1);
        }

        public List<Course> GetAllCourses()
        {
            return _courses;
        }

        public Course GetCourseById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public bool EnrollUserInCourse(int courseId, User user)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null && !course.EnrolledUsers.Any(u => u.Id == user.Id))
            {
                course.EnrolledUsers.Add(user);
                return true;
            }
            return false;
        }

       public List<Course> GetUserCourses(int userId)
       {
           return _courses.Where(c => c.EnrolledUsers.Any(u => u.Id == userId)).ToList();
       }

    }
}
