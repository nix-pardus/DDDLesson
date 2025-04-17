namespace DDDLesson.Common;

public interface IEntry<TEntryId> where TEntryId : IEquatable<TEntryId>, new()
{
    TEntryId Id { get; }
}
