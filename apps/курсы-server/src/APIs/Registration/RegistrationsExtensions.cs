using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class RegistrationsExtensions
{
    public static Registration ToDto(this RegistrationDbModel model)
    {
        return new Registration
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static RegistrationDbModel ToModel(this RegistrationUpdateInput updateDto, RegistrationWhereUniqueInput uniqueId)
    {
        var registration = new RegistrationDbModel
        {
            Id = uniqueId.Id
        };

        if (updateDto.CreatedAt != null)
        {
            registration.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            registration.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return registration;
    }

}
