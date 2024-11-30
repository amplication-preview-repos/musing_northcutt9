using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class RegistrationsServiceBase : IRegistrationsService
{
    protected readonly DbContext _context;
    public RegistrationsServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Registration
    /// </summary>
    public async Task<Registration> CreateRegistration(RegistrationCreateInput createDto)
    {
        var registration = new RegistrationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            registration.Id = createDto.Id;
        }


        _context.Registrations.Add(registration);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RegistrationDbModel>(registration.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Registration
    /// </summary>
    public async Task DeleteRegistration(RegistrationWhereUniqueInput uniqueId)
    {
        var registration = await _context.Registrations.FindAsync(uniqueId.Id);
        if (registration == null)
        {
            throw new NotFoundException();
        }

        _context.Registrations.Remove(registration);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Registrations
    /// </summary>
    public async Task<List<Registration>> Registrations(RegistrationFindManyArgs findManyArgs)
    {
        var registrations = await _context
              .Registrations

      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return registrations.ConvertAll(registration => registration.ToDto());
    }

    /// <summary>
    /// Meta data about Registration records
    /// </summary>
    public async Task<MetadataDto> RegistrationsMeta(RegistrationFindManyArgs findManyArgs)
    {

        var count = await _context
    .Registrations
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Registration
    /// </summary>
    public async Task<Registration> Registration(RegistrationWhereUniqueInput uniqueId)
    {
        var registrations = await this.Registrations(
                  new RegistrationFindManyArgs { Where = new RegistrationWhereInput { Id = uniqueId.Id } }
      );
        var registration = registrations.FirstOrDefault();
        if (registration == null)
        {
            throw new NotFoundException();
        }

        return registration;
    }

    /// <summary>
    /// Update one Registration
    /// </summary>
    public async Task UpdateRegistration(RegistrationWhereUniqueInput uniqueId, RegistrationUpdateInput updateDto)
    {
        var registration = updateDto.ToModel(uniqueId);



        _context.Entry(registration).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Registrations.Any(e => e.Id == registration.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

}
