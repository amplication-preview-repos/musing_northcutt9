using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RegistrationsControllerBase : ControllerBase
{
    protected readonly IRegistrationsService _service;
    public RegistrationsControllerBase(IRegistrationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Registration
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Registration>> CreateRegistration(RegistrationCreateInput input)
    {
        var registration = await _service.CreateRegistration(input);

        return CreatedAtAction(nameof(Registration), new { id = registration.Id }, registration);
    }

    /// <summary>
    /// Delete one Registration
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteRegistration([FromRoute()]
    RegistrationWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRegistration(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Registrations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Registration>>> Registrations([FromQuery()]
    RegistrationFindManyArgs filter)
    {
        return Ok(await _service.Registrations(filter));
    }

    /// <summary>
    /// Meta data about Registration records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RegistrationsMeta([FromQuery()]
    RegistrationFindManyArgs filter)
    {
        return Ok(await _service.RegistrationsMeta(filter));
    }

    /// <summary>
    /// Get one Registration
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Registration>> Registration([FromRoute()]
    RegistrationWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Registration(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Registration
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateRegistration([FromRoute()]
    RegistrationWhereUniqueInput uniqueId, [FromQuery()]
    RegistrationUpdateInput registrationUpdateDto)
    {
        try
        {
            await _service.UpdateRegistration(uniqueId, registrationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
