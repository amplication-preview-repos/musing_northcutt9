using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class AttendancesExtensions
{
    public static Attendance ToDto(this AttendanceDbModel model)
    {
        return new Attendance
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static AttendanceDbModel ToModel(this AttendanceUpdateInput updateDto, AttendanceWhereUniqueInput uniqueId)
    {
        var attendance = new AttendanceDbModel
        {
            Id = uniqueId.Id
        };

        if (updateDto.CreatedAt != null)
        {
            attendance.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            attendance.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return attendance;
    }

}
