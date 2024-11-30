using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class NotificationsController : NotificationsControllerBase
{
    public NotificationsController(INotificationsService service) : base(service)
    {
    }

}
