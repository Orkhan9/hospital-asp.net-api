using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class DepartmentReturnDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Doctors { get; set; }
    }
}