using System.Collections.Generic;
using Hospital.DAL.Entities;

namespace Hospital.BLL.DTO.Department
{
    public class DepartmentReturnDto:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Doctors { get; set; }
    }
}