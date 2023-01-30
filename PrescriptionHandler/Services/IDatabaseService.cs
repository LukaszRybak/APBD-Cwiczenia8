using PrescriptionHandler.Models;
using PrescriptionHandler.Models.DTO.Responses;

namespace PrescriptionHandler.Services
{
    public interface IDatabaseService
    {
        Task<DatabaseResponseDto> GetPrescriptionAsync(int idPrescription);
        Task<DatabaseResponseDto> GetDoctorsAsync();
        Task<DatabaseResponseDto> AddDoctorAsync(DoctorRequestDto newDoctor);
        Task<DatabaseResponseDto> UpdateDoctorAsync(int idDoctor, DoctorRequestDto updatedDoctor);
        Task<DatabaseResponseDto> DeleteDoctorAsync(int idDoctor);
    }
}
