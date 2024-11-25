using DuAn2_ThucTapAlta.DTO.Class;
using DuAn2_ThucTapAlta.Services;
using DuAn2_ThucTapAlta.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.Course;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Teacher,Manager")]
        public async Task<IActionResult> GetClassById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classes = await _classService.GetClassByIdAsync(id);

            if (classes == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(classes.ToClassDTO());
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher,Manager")]
        public async Task<IActionResult> GetAllClasses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classes = await _classService.GetAllClassesAsync();

            var classDto = classes.Select(s => s.ToClassDTO()).ToList();

            return Ok(classDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateClass(CreateClassDTO classDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (classDto == null)
            {
                return BadRequest(ModelState);
            }

            var classModel = classDto.ToClassFromCreateDTO();

            await _classService.CreateClassAsync(classModel);

            return CreatedAtAction(nameof(GetClassById), new { id = classModel.Id }, classModel.ToClassDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateClass(int id, UpdateClassDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classModel = await _classService.UpdateClassAsync(id, updateDto);

            if (classModel == null)
            {
                return NotFound();
            }

            return Ok(classModel.ToClassDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var result = await _classService.DeactivateClassAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "Admin,Teacher,Manager")]
        public async Task<IActionResult> ActivateClass(int id)
        {
            var result = await _classService.ActivateClassAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        [Authorize(Roles = "Admin,Teacher,Manager")]
        public async Task<IActionResult> GetInactiveClasses()
        {
            var inactiveClasses = await _classService.GetInactiveClassesAsync();

            if (!inactiveClasses.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var classDtos = inactiveClasses.Select(f => f.ToClassDTO()).ToList();
            return Ok(classDtos);
        }
    }
}
