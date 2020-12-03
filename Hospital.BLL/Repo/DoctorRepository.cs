using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hospital.BLL.Helpers;
using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<PagedList<Doctor>> GetDoctorsAsync(PaginationParams paginationParams)
        {
            var doctors = _context.Doctors.Include(d => d.Department);
            return await PagedList<Doctor>.CreateAsync(doctors,paginationParams.PageNumber,paginationParams.PageSize);
        }

        public async Task<List<Doctor>> GetDoctorByDepartmentIdAsync(int id)
        {
            var doctors = await _context.Doctors.Where(x => x.DepartmentId == id).Include(x => x.Department)
                .ToListAsync();
            return doctors;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.Include(d=>d.Department).FirstOrDefaultAsync(p => p.Id == id);
            return doctor;
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor,string webRoot)
        {
            var dbDoctor =await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);
            if (dbDoctor == null)
            {
                return dbDoctor;
            }
            
            string folderName = Path.Combine("images", "doctors");
            if (doctor.Photo!=null)
            {
                ImageExtension.DeleteImage(webRoot,folderName,dbDoctor.PhotoUrl);
                string fileName = await doctor.Photo.SaveImg(webRoot, folderName);
                dbDoctor.PhotoUrl = fileName;
            }
            
            dbDoctor.Name = doctor.Name;
            dbDoctor.Description = doctor.Description;
            dbDoctor.Facebook = doctor.Facebook;
            dbDoctor.Profession = doctor.Profession;
            dbDoctor.DepartmentId = doctor.DepartmentId;
            await _context.SaveChangesAsync();
            
            return dbDoctor;
        }

        public async Task<Doctor> DeleteDoctorAsync(int id,string webRoot)
        {
            var dbDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (dbDoctor == null) return dbDoctor;
            
            string folderName = Path.Combine("images", "doctors");
            
            _context.Doctors.Remove(dbDoctor);
            ImageExtension.DeleteImage(webRoot,folderName,dbDoctor.PhotoUrl);
            
            await _context.SaveChangesAsync();
            return dbDoctor;
        }
    }
}