using DuAn2_ThucTapAlta.Data;
using DuAn2_ThucTapAlta.DTO.FeeInformation;
using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Services
{
    public class FeeInformationService : IFeeInformationService
    {
        private readonly ApplicationDBContext _context;

        public FeeInformationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<FeeInformation> GetFeeInformationByIdAsync(int id)
        {
            return await _context.FeeInformations.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<FeeInformation>> GetAllFeeInformationsAsync()
        {
            return await _context.FeeInformations.ToListAsync();
        }

        public async Task<FeeInformation> CreateFeeInformationAsync(FeeInformation feeInformations)
        {
            await _context.FeeInformations.AddAsync(feeInformations);
            await _context.SaveChangesAsync();
            return feeInformations;
        }

        public async Task<FeeInformation> UpdateFeeInformationAsync(int id, UpdateFeeInformationDTO updateDto)
        {
            var existingFeeInformations = await _context.FeeInformations.FirstOrDefaultAsync(x => x.Id == id);

            if (existingFeeInformations == null)
            {
                return null;
            }

            existingFeeInformations.FeeType = updateDto.FeeType;
            existingFeeInformations.FeeLevel = updateDto.FeeLevel;
            existingFeeInformations.Discount = updateDto.Discount;
            existingFeeInformations.Note = updateDto.Note;
            existingFeeInformations.StudentId = updateDto.StudentId;
            existingFeeInformations.ClassId = updateDto.ClassId;

            await _context.SaveChangesAsync();
            return existingFeeInformations;
        }

        public async Task<bool> DeactivateFeeInformationAsync(int id)
        {
            var feeInformations = await _context.FeeInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (feeInformations == null)
            {
                return false;
            }

            feeInformations.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateFeeInformationAsync(int id)
        {
            var feeInformations = await _context.FeeInformations.FirstOrDefaultAsync(x => x.Id == id);
            if (feeInformations == null || feeInformations.IsActive)
            {
                return false;
            }

            feeInformations.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FeeInformation>> GetInactiveFeeInformationsAsync()
        {
            return await _context.FeeInformations
                                 .Where(f => !f.IsActive)
                                 .ToListAsync();
        }
    }
}