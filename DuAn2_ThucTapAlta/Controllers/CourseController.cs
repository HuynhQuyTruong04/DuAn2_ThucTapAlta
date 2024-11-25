using DuAn2_ThucTapAlta.DTO.Course;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(course.ToCourseDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseService.GetAllCoursesAsync();

            var courseDto = course.Select(s => s.ToCourseDTO()).ToList();

            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (courseDto == null)
            {
                return BadRequest(ModelState);
            }

            var courseModel = courseDto.ToCourseFromCreateDTO();

            await _courseService.CreateCourseAsync(courseModel);

            return CreatedAtAction(nameof(GetCourseById), new { id = courseModel.Id }, courseModel.ToCourseDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseModel = await _courseService.UpdateCourseAsync(id, updateDto);

            if (courseModel == null)
            {
                return NotFound("Chuyến bay không tồn tại.");
            }

            return Ok(courseModel.ToCourseDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeactivateCourseAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateCourse(int id)
        {
            var result = await _courseService.ActivateCourseAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveCourses()
        {
            var inactiveCourses = await _courseService.GetInactiveCoursesAsync();

            if (!inactiveCourses.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var courseDtos = inactiveCourses.Select(f => f.ToCourseDTO()).ToList();
            return Ok(courseDtos);
        }
    }
}
