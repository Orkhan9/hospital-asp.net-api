using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.BLL.Helpers;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IDoctorRepository
    {
        Task<PagedList<Doctor>> GetDoctorsAsync(PaginationParams paginationParams);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<List<Doctor>> GetDoctorByDepartmentIdAsync(int id);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor,string webRoot);
        Task<Doctor> DeleteDoctorAsync(int id,string webRoot);
    }
}