using DuAn2_ThucTapAlta.DTO.Subject;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjects = await _subjectService.GetSubjectByIdAsync(id);

            if (subjects == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(subjects.ToSubjectDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjects = await _subjectService.GetAllSubjectsAsync();

            var subjectDto = subjects.Select(s => s.ToSubjectDTO()).ToList();

            return Ok(subjectDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(CreateSubjectDTO subjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (subjectDto == null)
            {
                return BadRequest(ModelState);
            }

            var subjectModel = subjectDto.ToSubjectFromCreateDTO();

            await _subjectService.CreateSubjectAsync(subjectModel);

            return CreatedAtAction(nameof(GetSubjectById), new { id = subjectModel.Id }, subjectModel.ToSubjectDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, UpdateSubjectDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectModel = await _subjectService.UpdateSubjectAsync(id, updateDto);

            if (subjectModel == null)
            {
                return NotFound();
            }

            return Ok(subjectModel.ToSubjectDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _subjectService.DeactivateSubjectAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateSubject(int id)
        {
            var result = await _subjectService.ActivateSubjectAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveSubjects()
        {
            var inactiveSubjects = await _subjectService.GetInactiveSubjectsAsync();

            if (!inactiveSubjects.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var subjectDtos = inactiveSubjects.Select(f => f.ToSubjectDTO()).ToList();
            return Ok(subjectDtos);
        }
    }
}
