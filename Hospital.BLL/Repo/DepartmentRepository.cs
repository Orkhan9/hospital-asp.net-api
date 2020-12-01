using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hospital.BLL.Helpers;
using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments.Include(d => d.Doctors).ToListAsync();
            return departments;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.Include(d=>d.Doctors).FirstOrDefaultAsync(p => p.Id == id);
            return department;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            var dbDepartment =await _context.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);
            if (dbDepartment == null)
            {
                return dbDepartment;
            }
            
            dbDepartment.Name = department.Name;
            dbDepartment.Description = department.Description;
            await _context.SaveChangesAsync();
            
            return dbDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(int id)
        {
            var dbDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (dbDepartment == null) return dbDepartment;
            
            await _context.SaveChangesAsync();
            return dbDepartment;
        }
    }
}