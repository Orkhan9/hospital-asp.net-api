using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO.About;
using Hospital.BLL.DTO.Appointment;
using Hospital.BLL.DTO.Bio;
using Hospital.BLL.DTO.Blog;
using Hospital.BLL.DTO.Comment;
using Hospital.BLL.DTO.Department;
using Hospital.BLL.DTO.Doctor;
using Hospital.BLL.DTO.Product;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Mapper
{
    public class MapperProfile:Profile
    {
        private static string BaseUrlDoctor = "http://localhost:5000/images/doctors/";
        private static string BaseUrlBlog = "http://localhost:5000/images/blog/";
        private static string BaseUrlProduct = "http://localhost:5000/images/shop/";
        private static string BaseUrlLogo = "http://localhost:5000/images/logo/";
        private static string BaseUrlAbout = "http://localhost:5000/images/about/";
        public MapperProfile()
        {
            CreateMap<Doctor, DoctorReturnDto>()
                .ForMember(x => x.Department
                    , o =>
                        o.MapFrom(x => x.Department.Name))
                .ForMember(x => x.PhotoUrl
                    , o =>
                        o.MapFrom(x => BaseUrlDoctor+x.PhotoUrl));

            CreateMap<Appointment, AppointmentReturnDto>()
                .ForMember(x => x.Doctor
                    , o =>
                        o.MapFrom(x => x.Doctor.Name));


            CreateMap<Blog, BlogReturnDto>()
                .ForMember(x => x.Comments
                    , o =>
                        o.MapFrom(x => x.Comments.Select(x => x.Context)))
                .ForMember(x => x.PhotoUrl
                    , o =>
                        o.MapFrom(x => BaseUrlBlog+x.PhotoUrl));
            
            CreateMap<Department, DepartmentReturnDto>()
                .ForMember(x => x.Doctors
                    , o =>
                        o.MapFrom(x => x.Doctors.Select(x => x.Name)));
            
            CreateMap<Comment, CommentReturnDto>()
                .ForMember(x => x.Blog
                    , o =>
                        o.MapFrom(x => x.Blog.Title))
                .ForMember(x => x.User
                    , o =>
                        o.MapFrom(x => x.User.Name));;
            
            CreateMap<Product,ProductReturnDto>()
                .ForMember(x => x.ProductType
                    , o =>
                        o.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.ProductBrand
                    , o =>
                        o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.PictureUrl
                    , o =>
                        o.MapFrom(x => BaseUrlProduct + x.PictureUrl));
            
            CreateMap<Bio, BioReturnDto>()
                .ForMember(x => x.LogoUrl
                    , o =>
                        o.MapFrom(x => BaseUrlLogo+x.LogoUrl));
            
            CreateMap<About, AboutReturnDto>()
                .ForMember(x => x.PhotoUrl
                    , o =>
                        o.MapFrom(x => BaseUrlAbout+x.PhotoUrl));
            
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            
            CreateMap<BlogCreateDto,Blog>();
            CreateMap<BlogUpdateDto, Blog>();
            
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto,Department>();
        }
    }
}