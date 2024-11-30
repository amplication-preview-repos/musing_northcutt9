using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class RegistrationsController : RegistrationsControllerBase
{
    public RegistrationsController(IRegistrationsService service) : base(service)
    {
    }

}
