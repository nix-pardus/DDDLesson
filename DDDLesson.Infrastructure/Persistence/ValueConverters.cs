using DDDLesson.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DDDLesson.Infrastructure.Persistence;


public class PackagingTypeIdConverter : ValueConverter<PackagingTypeId, Guid>
{
    public PackagingTypeIdConverter() : base(v => v.Value, v => new PackagingTypeId(v)) { }
}



public class WorkerIdConverter : ValueConverter<WorkerId, Guid>
{
    public WorkerIdConverter() : base(v => v.Value, v => new WorkerId(v)) { }
}



public class WorkUnitIdConverter : ValueConverter<WorkUnitId, Guid>
{
    public WorkUnitIdConverter() : base(v => v.Value, v => new WorkUnitId(v)) { }
}



public class WorkDayIdConverter : ValueConverter<WorkDayId, Guid>
{
    public WorkDayIdConverter() : base(v => v.Value, v => new WorkDayId(v)) { }
}