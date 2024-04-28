using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Grades = new HashSet<Grade>();
        }

        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? HireDate { get; set; }
        public string? SubjectTaught { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
