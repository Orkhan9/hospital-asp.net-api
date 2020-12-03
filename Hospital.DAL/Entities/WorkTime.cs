using System;

namespace Hospital.DAL.Entities
{
    public class WorkTime:BaseEntity
    {
        public DateTime Monday { get; set; }
        public DateTime Tuesday { get; set; }
    }
}