using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEBAPI.Models
{
    public partial class prueba_tecnicaContext : DbContext
    {
        public prueba_tecnicaContext()
        {
        }

        public prueba_tecnicaContext(DbContextOptions<prueba_tecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TM9G5JJ\\LOCAL; Database=prueba_tecnica; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.Property(e => e.GradeDate)
                    .HasColumnType("date")
                    .HasColumnName("grade_date");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Grades__course_i__6D0D32F4");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Grades__student___6B24EA82");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Grades__teacher___6C190EBB");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Students__course__66603565");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.SubjectTaught)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("subject_taught");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("updated_by");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
