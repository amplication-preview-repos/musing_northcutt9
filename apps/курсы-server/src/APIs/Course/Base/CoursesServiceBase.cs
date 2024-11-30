using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class CoursesServiceBase : ICoursesService
{
    protected readonly DbContext _context;
    public CoursesServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Course
    /// </summary>
    public async Task<Course> CreateCourse(CourseCreateInput createDto)
    {
        var course = new CourseDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            course.Id = createDto.Id;
        }


        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CourseDbModel>(course.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Course
    /// </summary>
    public async Task DeleteCourse(CourseWhereUniqueInput uniqueId)
    {
        var course = await _context.Courses.FindAsync(uniqueId.Id);
        if (course == null)
        {
            throw new NotFoundException();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Courses
    /// </summary>
    public async Task<List<Course>> Courses(CourseFindManyArgs findManyArgs)
    {
        var courses = await _context
              .Courses

      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return courses.ConvertAll(course => course.ToDto());
    }

    /// <summary>
    /// Meta data about Course records
    /// </summary>
    public async Task<MetadataDto> CoursesMeta(CourseFindManyArgs findManyArgs)
    {

        var count = await _context
    .Courses
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Course
    /// </summary>
    public async Task<Course> Course(CourseWhereUniqueInput uniqueId)
    {
        var courses = await this.Courses(
                  new CourseFindManyArgs { Where = new CourseWhereInput { Id = uniqueId.Id } }
      );
        var course = courses.FirstOrDefault();
        if (course == null)
        {
            throw new NotFoundException();
        }

        return course;
    }

    /// <summary>
    /// Update one Course
    /// </summary>
    public async Task UpdateCourse(CourseWhereUniqueInput uniqueId, CourseUpdateInput updateDto)
    {
        var course = updateDto.ToModel(uniqueId);



        _context.Entry(course).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Courses.Any(e => e.Id == course.Id))
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
