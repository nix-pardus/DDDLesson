using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using MediatR;

namespace DDDLesson.Domain.PackagingTypes.DeletePackagingType;

public class DeletePackagingTypeCommandHandler : IRequestHandler<DeletePackagingTypeCommand, bool>
{
    private readonly IPackagingTypeEntityRepository repository;

    public DeletePackagingTypeCommandHandler(IPackagingTypeEntityRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> Handle(DeletePackagingTypeCommand request, CancellationToken cancellationToken)
    {
        return await repository.DeleteAsync(request.PackagingTypeId);
    }
}
