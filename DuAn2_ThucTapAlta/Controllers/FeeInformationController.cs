using DuAn2_ThucTapAlta.DTO.FeeInformation;
using DuAn2_ThucTapAlta.Mappers;
using DuAn2_ThucTapAlta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAn2_ThucTapAlta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeInformationController : ControllerBase
    {
        private readonly IFeeInformationService _feeInformationService;

        public FeeInformationController(IFeeInformationService feeInformationService)
        {
            _feeInformationService = feeInformationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeeInformationById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feeinformations = await _feeInformationService.GetFeeInformationByIdAsync(id);

            if (feeinformations == null)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(feeinformations.ToFeeInformationDTO());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeeInformations()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feeinformations = await _feeInformationService.GetAllFeeInformationsAsync();

            var subjectDto = feeinformations.Select(s => s.ToFeeInformationDTO()).ToList();

            return Ok(subjectDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeeInformation(CreateFeeInformationDTO feeinformationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (feeinformationDto == null)
            {
                return BadRequest(ModelState);
            }

            var feeinformationModel = feeinformationDto.ToFeeInformationFromCreateDTO();

            await _feeInformationService.CreateFeeInformationAsync(feeinformationModel);

            return CreatedAtAction(nameof(GetFeeInformationById), new { id = feeinformationModel.Id }, feeinformationModel.ToFeeInformationDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeeInformation(int id, UpdateFeeInformationDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feeinformationModel = await _feeInformationService.UpdateFeeInformationAsync(id, updateDto);

            if (feeinformationModel == null)
            {
                return NotFound();
            }

            return Ok(feeinformationModel.ToFeeInformationDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeeInformation(int id)
        {
            var result = await _feeInformationService.DeactivateFeeInformationAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateFeeInformation(int id)
        {
            var result = await _feeInformationService.ActivateFeeInformationAsync(id);

            if (!result)
            {
                return NotFound(new { message = "NotFound" });
            }

            return Ok(new { message = "Ok" });
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveFeeInformations()
        {
            var inactiveFeeInformations = await _feeInformationService.GetInactiveFeeInformationsAsync();

            if (!inactiveFeeInformations.Any())
            {
                return NotFound(new { message = "NotFound" });
            }

            var feeinformationDtos = inactiveFeeInformations.Select(f => f.ToFeeInformationDTO()).ToList();
            return Ok(feeinformationDtos);
        }
    }
}
