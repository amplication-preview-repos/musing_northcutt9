using .Infrastructure;

namespace .APIs;

public class RegistrationsService : RegistrationsServiceBase
{
    public RegistrationsService(DbContext context) : base(context)
    {
    }

}
