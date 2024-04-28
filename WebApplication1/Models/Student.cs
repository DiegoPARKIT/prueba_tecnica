using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CourseId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
