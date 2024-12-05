using DuAn2_ThucTapAlta.DTO.Salary;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salaries = await _salaryService.GetSalaryByIdAsync(id);

            if (salaries == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(salaries.ToSalaryDTO());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetAllSalaries()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salaries = await _salaryService.GetAllSalariesAsync();

            var salaryDto = salaries.Select(s => s.ToSalaryDTO()).ToList();

            return Ok(salaryDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateSalary(CreateSalaryDTO salaryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (salaryDto == null)
            {
                return BadRequest(ModelState);
            }

            var salaryModel = salaryDto.ToSalaryFromCreateDTO();

            await _salaryService.CreateSalaryAsync(salaryModel);

            return CreatedAtAction(nameof(GetSalaryById), new { id = salaryModel.Id }, salaryModel.ToSalaryDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateSalary(int id, UpdateSalaryDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salaryModel = await _salaryService.UpdateSalaryAsync(id, updateDto);

            if (salaryModel == null)
            {
                return NotFound();
            }

            return Ok(salaryModel.ToSalaryDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var result = await _salaryService.DeactivateSalaryAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ActivateSalary(int id)
        {
            var result = await _salaryService.ActivateSalaryAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetInactiveSalries()
        {
            var inactiveSalaries = await _salaryService.GetInactiveSalariesAsync();

            if (!inactiveSalaries.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var salaryDtos = inactiveSalaries.Select(f => f.ToSalaryDTO()).ToList();
            return Ok(salaryDtos);
        }
    }
}
