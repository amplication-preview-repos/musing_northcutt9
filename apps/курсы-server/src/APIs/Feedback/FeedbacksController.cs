using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class FeedbacksController : FeedbacksControllerBase
{
    public FeedbacksController(IFeedbacksService service) : base(service)
    {
    }

}
