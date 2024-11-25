using DuAn2_ThucTapAlta.DTO.Enrollment;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollments = await _enrollmentService.GetEnrollmentByIdAsync(id);

            if (enrollments == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(enrollments.ToEnrollmentDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();

            var classDto = enrollments.Select(s => s.ToEnrollmentDTO()).ToList();

            return Ok(classDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDTO enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (enrollmentDto == null)
            {
                return BadRequest(ModelState);
            }

            var enrollmentModel = enrollmentDto.ToEnrollmentFromCreateDTO();

            await _enrollmentService.CreateEnrollmentAsync(enrollmentModel);

            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollmentModel.Id }, enrollmentModel.ToEnrollmentDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, UpdateEnrollmentDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enrollmentModel = await _enrollmentService.UpdateEnrollmentAsync(id, updateDto);

            if (enrollmentModel == null)
            {
                return NotFound();
            }

            return Ok(enrollmentModel.ToEnrollmentDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var result = await _enrollmentService.DeactivateEnrollmentAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateEnrollment(int id)
        {
            var result = await _enrollmentService.ActivateEnrollmentAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveEnrollments()
        {
            var inactiveEnrollments = await _enrollmentService.GetInactiveEnrollmentsAsync();

            if (!inactiveEnrollments.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var enrollmentDtos = inactiveEnrollments.Select(f => f.ToEnrollmentDTO()).ToList();
            return Ok(enrollmentDtos);
        }
    }
}
