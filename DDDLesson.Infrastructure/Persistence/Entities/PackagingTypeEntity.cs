using DDDLesson.Common;
using System.ComponentModel.DataAnnotations;

namespace DDDLesson.Infrastructure.Persistence.Entities;

public sealed class PackagingTypeEntity : IEntry<PackagingTypeId>
{
    [Key]
    public required PackagingTypeId Id { get; set; }
    [Required, MaxLength(128)]
    public required string Name { get; set; }
    [Required]
    public required decimal PricePerSquareMeter { get; set; }
    [Required]
    public required decimal PricePerSquareMeterOnWeekend { get; set; }
}
