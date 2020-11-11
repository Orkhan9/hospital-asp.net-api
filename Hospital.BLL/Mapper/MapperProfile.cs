using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.DTO.Appointment;
using Hospital.BLL.DTO.Comment;
using Hospital.BLL.DTO.Product;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Doctor, DoctorReturnDto>()
                .ForMember(x => x.Department
                    , o =>
                        o.MapFrom(x => x.Department.Name));

            CreateMap<Appointment, AppointmentReturnDto>()
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
            
            CreateMap<Comment, CommentReturnDto>()
                .ForMember(x => x.Blog
                    , o =>
                        o.MapFrom(x => x.Blog.Title));
            
            CreateMap<Product,ProductReturnDto>()
                .ForMember(x => x.ProductType
                    , o =>
                        o.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.ProductBrand
                    , o =>
                        o.MapFrom(x => x.ProductBrand.Name));
        }
    }
}