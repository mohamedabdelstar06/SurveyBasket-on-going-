using SurveyBasket.Api.Mapping;

namespace SurveyBasket.Api.Controllers;


[Route("api/[controller]")]

[ApiController] //Assign parameter binding
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;


    [HttpGet("")] // there arre two ways to generate template this is one And the two => [Route("")]
    public IActionResult GetAll()
    {
        var polls = _pollService.GetAll();
        return Ok(polls.MapToResponse());
    }

    [HttpGet("{id}")]  //Bad request 
    public IActionResult Get([FromRoute] int id)
    {
        var poll = _pollService.Get(id);
        return poll is null ? NotFound(poll) : Ok(poll.MapToResponse());

    }
    [HttpPost("")]
    public IActionResult Add( [FromForm] CreatePollRequest  request)
    {
        var newPoll = _pollService.Add(request.MapToPoll());
        return CreatedAtAction(nameof(Get), new { newPoll.Id }, newPoll);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id,[FromBody] CreatePollRequest request)
    {
        var isUpdated = _pollService.Update(id, request.MapToPoll());
        if (!isUpdated)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollService.Delete(id);
        if (!isDeleted)
            return NotFound();
        return NoContent();
    }

}
