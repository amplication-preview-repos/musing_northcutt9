using .Infrastructure;

namespace .APIs;

public class AttendancesService : AttendancesServiceBase
{
    public AttendancesService(DbContext context) : base(context)
    {
    }

}
