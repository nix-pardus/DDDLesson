using CommunityToolkit.Mvvm.Input;
using DDDLesson.Domain.PackagingTypes.CreatePackagingType;
using DDDLesson.Domain.PackagingTypes.DeletePackagingType;
using DDDLesson.Domain.PackagingTypes.EditPackagingType;
using DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;
using System.Threading;
using System.Threading.Tasks;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public partial class PackagingTypesViewModel
{
    [RelayCommand]
    public async Task GetPackagingTypesAsync()
    {
        var response = await mediator.Send(new GetPackagingTypesListQuery());
        PackagingTypesList = mapper.Map<GetPackagingTypesListResponse>(response).Entries;
    }


    [RelayCommand(CanExecute = nameof(CanCreatePackagingType))]
    public async Task SavePackagingTypeAsync(CancellationToken cancellationToken)
    {
        if (!isEditMode)
        {
            await mediator.Send(new CreatePackagingTypeCommand()
            {
                Name = PackagingTypeName,
                PricePerSquareMeter = PricePerSquareMeter!.Value,
                PricePerSquareMeterOnWeeken = PricePerSquareMeterOnWeeken!.Value
            }, cancellationToken);
        }
        else
        {
            await mediator.Send(new EditPackagingTypeCommand()
            {
                Id = SelectedPackagingType.Id,
                Name = PackagingTypeName,
                PricePerSquareMeter = PricePerSquareMeter!.Value,
                PricePerSquareMeterOnWeeken = PricePerSquareMeterOnWeeken!.Value
            }, cancellationToken);
            isEditMode = false;
            IsPaneOpen = false;
        }
        PackagingTypeName = string.Empty;
        PricePerSquareMeter = null;
        PricePerSquareMeterOnWeeken = null;
    }

    [RelayCommand(CanExecute = nameof(CanDeleteOrEditPackagingType))]
    public void EditPackagingType()
    {
        isEditMode = true;
        IsPaneOpen = true;
        PackagingTypeName = SelectedPackagingType.Name;
        PricePerSquareMeter = SelectedPackagingType?.PricePerSquareMeter;
        PricePerSquareMeterOnWeeken = SelectedPackagingType?.PricePerSquareMeterOnWeekend;
    }


    [RelayCommand(CanExecute = nameof(CanDeleteOrEditPackagingType))]
    public async Task DeletePackagingTypeAsync(CancellationToken cancellationToken)
    {
        await mediator.Send(new DeletePackagingTypeCommand()
        {
            PackagingTypeId = SelectedPackagingType.Id
        }, cancellationToken);
    }


    [RelayCommand]
    private void GoBack()
    {
        navigationService.GoBack();
    }

    [RelayCommand]
    private void SplitViewPaneOpen()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    [RelayCommand]
    private void SplitViewPaneClose()
    {
        IsPaneOpen = false;
        PackagingTypeName = string.Empty;
        PricePerSquareMeter = null;
        PricePerSquareMeterOnWeeken = null;
    }
}
