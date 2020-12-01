using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(int id);
    }
}