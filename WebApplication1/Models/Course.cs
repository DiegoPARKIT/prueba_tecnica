using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
