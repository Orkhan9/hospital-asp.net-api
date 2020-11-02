using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}