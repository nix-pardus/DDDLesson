using DDDLesson.Common;
using System.ComponentModel.DataAnnotations;

namespace DDDLesson.Infrastructure.Persistence.Entities;

public sealed class WorkerEntity : IEntry<WorkerId>
{
    [Key]
    public required WorkerId Id {  get; set; }
    [Required, MaxLength(128)]
    public required string Name { get; set; }
}
