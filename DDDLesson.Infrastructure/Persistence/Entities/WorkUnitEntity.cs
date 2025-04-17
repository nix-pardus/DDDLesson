using DDDLesson.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDLesson.Infrastructure.Persistence.Entities;

public sealed class WorkUnitEntity : IEntry<WorkUnitId>
{
    [Key]
    public required WorkUnitId Id { get; set; }

    [ForeignKey(nameof(Worker))]
    public required WorkerId WorkerId { get; set; }
    public required WorkerEntity Worker { get; set; }

    [ForeignKey(nameof(PackagingType))]
    public required PackagingTypeId PackagingTypeId { get; set; }
    public required PackagingTypeEntity PackagingType { get; set; }

    public required decimal Area { get; set; }

    [ForeignKey(nameof(WorkDay))]
    public required WorkDayId WorkDayId { get; set; }
    public required WorkDayEntity WorkDay { get; set; }
}
