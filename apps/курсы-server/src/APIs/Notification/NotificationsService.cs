using .Infrastructure;

namespace .APIs;

public class NotificationsService : NotificationsServiceBase
{
    public NotificationsService(DbContext context) : base(context)
    {
    }

}
