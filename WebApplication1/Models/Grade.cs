using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public double? Grade1 { get; set; }
        public DateTime? GradeDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
