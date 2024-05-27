using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services; // User sınıfını içeren isim alanını ekleyin

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("{courseId}/enroll")]
                public IActionResult EnrollUserInCourse(int courseId, [FromBody] int userId)
                {
                    var user = new YourNamespace.Services.User { Id = userId };
                    var result = _courseService.EnrollUserInCourse(courseId, user);
                    if (result)
                    {
                        var course = _courseService.GetCourseById(courseId);
                        if (course == null)
                        {
                            return NotFound(new { message = "Course not found after enrollment" });
                        }

                        return Ok(new { message = "User enrolled in the course successfully", course = course });
                    }
                    else
                    {
                        return BadRequest(new { message = "User is already enrolled in the course or course does not exist" });
                    }
                }

                [HttpGet("user/{userId}")]
                        public IActionResult GetUserCourses(int userId)
                        {
                            var userCourses = _courseService.GetUserCourses(userId);
                            if (userCourses == null || !userCourses.Any())
                            {
                                return NotFound(new { message = "No courses found for this user" });
                            }

                            return Ok(userCourses);
                        }

    }
}
