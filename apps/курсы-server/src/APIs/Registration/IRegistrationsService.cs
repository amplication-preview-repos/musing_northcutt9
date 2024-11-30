using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IRegistrationsService
{
    /// <summary>
    /// Create one Registration
    /// </summary>
    public Task<Registration> CreateRegistration(RegistrationCreateInput registration);
    /// <summary>
    /// Delete one Registration
    /// </summary>
    public Task DeleteRegistration(RegistrationWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many Registrations
    /// </summary>
    public Task<List<Registration>> Registrations(RegistrationFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about Registration records
    /// </summary>
    public Task<MetadataDto> RegistrationsMeta(RegistrationFindManyArgs findManyArgs);
    /// <summary>
    /// Get one Registration
    /// </summary>
    public Task<Registration> Registration(RegistrationWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one Registration
    /// </summary>
    public Task UpdateRegistration(RegistrationWhereUniqueInput uniqueId, RegistrationUpdateInput updateDto);
}
