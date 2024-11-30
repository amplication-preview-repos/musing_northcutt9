using .Infrastructure;

namespace .APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(DbContext context) : base(context)
    {
    }

}
