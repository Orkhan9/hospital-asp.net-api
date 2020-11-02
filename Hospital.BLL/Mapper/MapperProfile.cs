using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.Department
                    , o =>
                        o.MapFrom(x => x.Department.Name));

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.Doctor
                    , o =>
                        o.MapFrom(x => x.Doctor.Name));


            CreateMap<Blog, BlogReturnDto>()
                .ForMember(x => x.Comments
                    , o =>
                        o.MapFrom(x => x.Comments.Select(x => x.Context)));
            
            CreateMap<Department, DepartmentReturnDto>()
                .ForMember(x => x.Doctors
                    , o =>
                        o.MapFrom(x => x.Doctors.Select(x => x.Name)));
        }
    }
}