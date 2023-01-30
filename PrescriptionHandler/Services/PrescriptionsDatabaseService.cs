using Microsoft.EntityFrameworkCore;
using PrescriptionHandler.Models;
using PrescriptionHandler.Models.DTO.Responses;

namespace PrescriptionHandler.Services
{
    public class PrescriptionsDatabaseService : IDatabaseService
    {
        private readonly PrescriptionsDbContext _context;

        public PrescriptionsDatabaseService(PrescriptionsDbContext context)
        {
            _context = context;
        }

        public async Task<DatabaseResponseDto> GetDoctorsAsync()
        {
            var doctors = await _context.Doctors.Select(d => new
            {
                idDoctor = d.IdDoctor,
                firstName = d.FirstName,
                lastName = d.LastName,
                email = d.Email,
            }).ToListAsync();

            return new DatabaseResponseDto(200, "", doctors);
        }

        public async Task<DatabaseResponseDto> AddDoctorAsync(DoctorRequestDto newDoctor)
        {

            var doctor = new Doctor
            {
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Email = newDoctor.Email
            };
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return new DatabaseResponseDto(200, "New doctor added successfully", null);
        }

        public async Task<DatabaseResponseDto> UpdateDoctorAsync(int idDoctor, DoctorRequestDto updatedDoctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(idDoctor);
            if (existingDoctor == null)
            {
                return new DatabaseResponseDto(404, "Doctor not found", null);
            }
            existingDoctor.FirstName = updatedDoctor.FirstName;
            existingDoctor.LastName = updatedDoctor.LastName;
            existingDoctor.Email = updatedDoctor.Email;

            await _context.SaveChangesAsync();

            return new DatabaseResponseDto(200, "Doctor updated successfully", null);
        }
        public async Task<DatabaseResponseDto> DeleteDoctorAsync(int idDoctor)
        {
            var existingDoctor = await _context.Doctors.Where(d => idDoctor == d.IdDoctor).SingleOrDefaultAsync();
            if (existingDoctor == null)
            {
                return new DatabaseResponseDto(404, "Doctor not found", null);
            }

            _context.Doctors.Remove(existingDoctor);
            await _context.SaveChangesAsync();

            return new DatabaseResponseDto(200, "Doctor deleted successfully", null);
        }

        public Task<DatabaseResponseDto> GetPrescriptionAsync(int idPrescription)
        {
            throw new NotImplementedException();
        }
    }

}
