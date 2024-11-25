using DuAn2_ThucTapAlta.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn2_ThucTapAlta.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<FeeInformation> FeeInformations { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mối quan hệ giữa Class và Teacher (1:N)
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Class và Enrollment (1:N)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Course và Enrollment (1:N)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Student và Enrollment (1:N)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Class và Subject (1:N)
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Class và FeeInformation (1:N)
            modelBuilder.Entity<FeeInformation>()
                .HasOne(f => f.Class)
                .WithMany(c => c.FeeInformations)
                .HasForeignKey(f => f.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Student và FeeInformation (1:N)
            modelBuilder.Entity<FeeInformation>()
                .HasOne(f => f.Student)
                .WithMany(s => s.FeeInformations)
                .HasForeignKey(f => f.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Student và Grade (1:N)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.NoAction);


            // Mối quan hệ giữa Class và Grade (1:N)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Class)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa User và Student (1:1)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa User và Teacher (1:1)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne()
                .HasForeignKey<Teacher>(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Role và User (1:N)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Teacher và Salary (1:N)
            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Salaries)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Class và TimeTable (1:N)
            modelBuilder.Entity<TimeTable>()
                .HasOne(t => t.Class)
                .WithMany(c => c.TimeTables)
                .HasForeignKey(t => t.ClassId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mối quan hệ giữa Teacher và TimeTable (1:N)
            modelBuilder.Entity<TimeTable>()
                .HasOne(t => t.Teacher)
                .WithMany(tch => tch.TimeTables)
                .HasForeignKey(t => t.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
