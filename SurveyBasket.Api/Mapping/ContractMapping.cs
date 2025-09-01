
namespace SurveyBasket.Api.Mapping;

public static class ContractMapping
{
    public static PollResponse MapToResponse(this Poll poll)
    {
        return new()
        {
            Id = poll.Id,
            Title = poll.Title,
            Description = poll.Description
        };
    }
    public static IEnumerable<PollResponse> MapToResponse(this IEnumerable<Poll> polls)
    {
        return polls.Select(MapToResponse);
    }

    public static Poll MapToPoll(this CreatePollRequest request)
    {
        return new Poll
        {
            Title = request.Title,
            Description = request.Description
        };
    }
}