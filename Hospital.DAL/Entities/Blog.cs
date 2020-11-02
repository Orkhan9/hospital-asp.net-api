﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishTime { get; set; }
        public ICollection<Comment> Comments { get; set; }
        
        public Blog()
        {
            PublishTime=DateTime.Now;
        }
        
    }
}