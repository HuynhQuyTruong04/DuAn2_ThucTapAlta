using DuAn2_ThucTapAlta.DTO.Grade;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grades = await _gradeService.GetGradeByIdAsync(id);

            if (grades == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(grades.ToGradeDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grades = await _gradeService.GetAllGradesAsync();

            var gradeDto = grades.Select(s => s.ToGradeDTO()).ToList();

            return Ok(gradeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrade(CreateGradeDTO gradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (gradeDto == null)
            {
                return BadRequest(ModelState);
            }

            var gradeModel = gradeDto.ToGradeFromCreateDTO();

            await _gradeService.CreateGradeAsync(gradeModel);

            return CreatedAtAction(nameof(GetGradeById), new { id = gradeModel.Id }, gradeModel.ToGradeDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, UpdateGradeDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gradeModel = await _gradeService.UpdateGradeAsync(id, updateDto);

            if (gradeModel == null)
            {
                return NotFound();
            }

            return Ok(gradeModel.ToGradeDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var result = await _gradeService.DeactivateGradeAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateGrade(int id)
        {
            var result = await _gradeService.ActivateGradeAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveGrades()
        {
            var inactiveGrades = await _gradeService.GetInactiveGradesAsync();

            if (!inactiveGrades.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var gradeDtos = inactiveGrades.Select(f => f.ToGradeDTO()).ToList();
            return Ok(gradeDtos);
        }
    }
}
