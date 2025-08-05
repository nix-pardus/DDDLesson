using DDDLesson.Common;
using DDDLesson.Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using System;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;

public class GetWorkDaysListOfMonthResponseEntry
{
    public required WorkDayId Id { get; init; }
    public required DateTime Date { get; init; }
    public required IReadOnlyCollection<WorkUnitEntity>? WorkUnits { get; init; }
    public required bool IsWeekend { get; init; }
}
