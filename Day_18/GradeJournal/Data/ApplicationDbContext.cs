using Microsoft.EntityFrameworkCore;
using GradeJournal.Models;

namespace GradeJournal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<EnrollmentModel> Enrollments { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
        public DbSet<GradeModel> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=journal.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                entity.Ignore(e => e.AverageGrade);

                entity.HasMany(s => s.Attendance)
                      .WithOne(a => a.Student)
                      .HasForeignKey(a => a.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Grades)
                      .WithOne()
                      .HasForeignKey(g => g.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AttendanceRecord>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();
            });

            modelBuilder.Entity<GradeModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Subject).HasMaxLength(100);
                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<CourseModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EnrollmentModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Enrollments)
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(e => e.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired();
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}