using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class CoursesController : CoursesControllerBase
{
    public CoursesController(ICoursesService service) : base(service)
    {
    }

}
