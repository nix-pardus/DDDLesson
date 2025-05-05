using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public class GetPackagingTypesListResponse
{
    public required ObservableCollection<GetPackagingTypesListResponseEntry> Entries { get; init; }
}
