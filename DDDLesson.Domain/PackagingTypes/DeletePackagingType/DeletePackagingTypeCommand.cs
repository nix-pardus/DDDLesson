using DDDLesson.Common;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.DeletePackagingType;

public class DeletePackagingTypeCommand : IRequest<bool>
{
    public required PackagingTypeId PackagingTypeId { get; init; }
}
