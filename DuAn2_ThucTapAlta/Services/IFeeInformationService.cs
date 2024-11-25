using DuAn2_ThucTapAlta.DTO.FeeInformation;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Services
{
    public interface IFeeInformationService
    {
        Task<FeeInformation> GetFeeInformationByIdAsync(int id);
        Task<IEnumerable<FeeInformation>> GetAllFeeInformationsAsync();
        Task<FeeInformation> CreateFeeInformationAsync(FeeInformation feeInformations);
        Task<FeeInformation> UpdateFeeInformationAsync(int id, UpdateFeeInformationDTO updateDto);
        Task<bool> DeactivateFeeInformationAsync(int id);
        Task<bool> ActivateFeeInformationAsync(int id);
        Task<IEnumerable<FeeInformation>> GetInactiveFeeInformationsAsync();
    }
}
