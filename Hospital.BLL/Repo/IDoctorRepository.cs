using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<List<Doctor>> GetDoctorByDepartmentIdAsync(int id);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor,string webRoot);
        Task<Doctor> DeleteDoctorAsync(int id,string webRoot);
    }
}