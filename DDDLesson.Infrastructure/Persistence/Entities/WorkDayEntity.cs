using DDDLesson.Common;
using System.ComponentModel.DataAnnotations;

namespace DDDLesson.Infrastructure.Persistence.Entities;

public sealed class WorkDayEntity : IEntry<WorkDayId>
{
    [Key]
    public required WorkDayId Id { get; set; }
    [Required]
    public required DateTime Date { get; init; }

    public IReadOnlyCollection<WorkUnitEntity>? WorkUnits { get; init; }

    public required bool IsWeekend { get; init; }
}
