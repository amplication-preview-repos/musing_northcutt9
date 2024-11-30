using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class AttendancesController : AttendancesControllerBase
{
    public AttendancesController(IAttendancesService service) : base(service)
    {
    }

}
