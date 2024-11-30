using .Infrastructure;

namespace .APIs;

public class CoursesService : CoursesServiceBase
{
    public CoursesService(DbContext context) : base(context)
    {
    }

}
