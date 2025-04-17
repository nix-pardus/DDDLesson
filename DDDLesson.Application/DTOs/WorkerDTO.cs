using DDDLesson.Common;

namespace DDDLesson.Application.DTOs;

public class WorkerDTO
{
    public required WorkerId Id { get; init; }
    public required string Name { get; init; }
}
