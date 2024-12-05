using DuAn2_ThucTapAlta.DTO.Timetable;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService _timeTableService;

        public TimeTableController(ITimeTableService timeTableService)
        {
            _timeTableService = timeTableService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Teacher, Manager, Student")]
        public async Task<IActionResult> GetTimeTableById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timetables = await _timeTableService.GetTimeTableByIdAsync(id);

            if (timetables == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(timetables.ToTimetableDTO());
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher, Manager, Student")]
        public async Task<IActionResult> GetAllTimeTables()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timetables = await _timeTableService.GetAllTimeTablesAsync();

            var timetableDto = timetables.Select(s => s.ToTimetableDTO()).ToList();

            return Ok(timetableDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> CreateTimeTable(CreateTimeTableDTO timetableDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (timetableDto == null)
            {
                return BadRequest(ModelState);
            }

            var timetableModel = timetableDto.ToTimeTableFromCreateDTO();

            await _timeTableService.CreateTimeTableAsync(timetableModel);

            return CreatedAtAction(nameof(GetTimeTableById), new { id = timetableModel.Id }, timetableModel.ToTimetableDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateTimeTable(int id, UpdateTimeTableDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classModel = await _timeTableService.UpdateTimeTableAsync(id, updateDto);

            if (classModel == null)
            {
                return NotFound();
            }

            return Ok(classModel.ToTimetableDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> DeleteTimeTable(int id)
        {
            var result = await _timeTableService.DeactivateTimeTableAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> ActivateTimeTable(int id)
        {
            var result = await _timeTableService.ActivateTimeTableAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetInactiveTimeTables()
        {
            var inactiveTimetables = await _timeTableService.GetInactiveTimeTablesAsync();

            if (!inactiveTimetables.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var timetableDtos = inactiveTimetables.Select(f => f.ToTimetableDTO()).ToList();
            return Ok(timetableDtos);
        }
    }
}
