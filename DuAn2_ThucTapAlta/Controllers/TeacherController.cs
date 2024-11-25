using DuAn2_ThucTapAlta.DTO.Teacher;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.GetTeacherByIdAsync(id);

            if (teacher == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(teacher.ToTeacherDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.GetAllTeachersAsync();

            var teacherDto = teacher.Select(s => s.ToTeacherDTO()).ToList();

            return Ok(teacherDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDTO teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (teacherDto == null)
            {
                return BadRequest(ModelState);
            }

            var teacherModel = teacherDto.ToTeacherFromCreateDTO();

            await _teacherService.CreateTeacherAsync(teacherModel);

            return CreatedAtAction(nameof(GetTeacherById), new { id = teacherModel.Id }, teacherModel.ToTeacherDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherModel = await _teacherService.UpdateTeacherAsync(id, updateDto);

            if (teacherModel == null)
            {
                return NotFound("Chuyến bay không tồn tại.");
            }

            return Ok(teacherModel.ToTeacherDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var result = await _teacherService.DeactivateTeacherAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateTeacher(int id)
        {
            var result = await _teacherService.ActivateTeacherAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveTeachers()
        {
            var inactiveTeachers = await _teacherService.GetInactiveTeachersAsync();

            if (!inactiveTeachers.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var teacherDtos = inactiveTeachers.Select(f => f.ToTeacherDTO()).ToList();
            return Ok(teacherDtos);
        }
    }
}
