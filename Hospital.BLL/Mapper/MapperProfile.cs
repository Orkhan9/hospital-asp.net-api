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
                .ForMember(x => x.Department, o => o.MapFrom(x => x.Department.Name));
            
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.Department, o => o.MapFrom(x => x.Department.Name));

            
        }
    }
}