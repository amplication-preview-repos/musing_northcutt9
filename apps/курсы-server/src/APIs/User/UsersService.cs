using .Infrastructure;

namespace .APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(DbContext context) : base(context)
    {
    }

}
