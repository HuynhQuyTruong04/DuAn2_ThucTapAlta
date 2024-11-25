using DuAn2_ThucTapAlta.DTO.FeeInformation;
using DuAn2_ThucTapAlta.Models;

namespace DuAn2_ThucTapAlta.Mappers
{
    public static class FeeInformationMapper
    {
        public static FeeInformationDTO ToFeeInformationDTO(this FeeInformation feeinformationModel)
        {
            return new FeeInformationDTO
            {
                Id = feeinformationModel.Id,
                FeeType = feeinformationModel.FeeType,
                FeeLevel = feeinformationModel.FeeLevel,
                Discount = feeinformationModel.Discount,
                Note = feeinformationModel.Note,
                StudentId = feeinformationModel.StudentId,
                ClassId = feeinformationModel.ClassId
            };
        }
        public static FeeInformation ToFeeInformationFromCreateDTO(this CreateFeeInformationDTO feeinformationModel)
        {
            return new FeeInformation
            {
                Id = feeinformationModel.Id,
                FeeType = feeinformationModel.FeeType,
                FeeLevel = feeinformationModel.FeeLevel,
                Discount = feeinformationModel.Discount,
                Note = feeinformationModel.Note,
                StudentId = feeinformationModel.StudentId,
                ClassId = feeinformationModel.ClassId
            };
        }
    }
}
