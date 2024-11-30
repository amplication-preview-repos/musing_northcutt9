using .APIs;

namespace ;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAttendancesService, AttendancesService>();
        services.AddScoped<ICoursesService, CoursesService>();
        services.AddScoped<IFeedbacksService, FeedbacksService>();
        services.AddScoped<INotificationsService, NotificationsService>();
        services.AddScoped<IRegistrationsService, RegistrationsService>();
        services.AddScoped<IUsersService, UsersService>();
    }

}
