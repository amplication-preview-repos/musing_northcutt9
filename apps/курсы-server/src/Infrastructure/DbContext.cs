using Microsoft.EntityFrameworkCore;
using .Infrastructure.Models;

namespace .Infrastructure;

public class DbContext : DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<RegistrationDbModel> Registrations { get; set; }

    public DbSet<CourseDbModel> Courses { get; set; }

    public DbSet<FeedbackDbModel> Feedbacks { get; set; }

    public DbSet<AttendanceDbModel> Attendances { get; set; }

    public DbSet<NotificationDbModel> Notifications { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
