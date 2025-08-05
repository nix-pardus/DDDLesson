using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public partial class PackagingTypesViewModel
{
    private ObservableCollection<GetPackagingTypesListResponseEntry> packagingTypesList;
    private GetPackagingTypesListResponseEntry selectedPackagingType;
    private string packagingTypeName = string.Empty;
    private decimal? pricePerSquareMeter;
    private decimal? pricePerSquareMeterOnWeeken;
    private bool isPaneOpen;
    private bool isEditMode;

    public bool IsPaneOpen
    {
        get => isPaneOpen;
        set
        {
            try
            {
                SetProperty(ref isPaneOpen, value);
            }
            catch { }
        }
    }
    public ObservableCollection<GetPackagingTypesListResponseEntry> PackagingTypesList
    {
        get => packagingTypesList;
        set
        {
            SetProperty(ref packagingTypesList, value);
        }
    }

    public GetPackagingTypesListResponseEntry SelectedPackagingType
    {
        get => selectedPackagingType;
        set
        {
            SetProperty(ref selectedPackagingType, value);
            OnPropertyChanged(nameof(CanDeleteOrEditPackagingType));
            DeletePackagingTypeCommand.NotifyCanExecuteChanged();
            EditPackagingTypeCommand.NotifyCanExecuteChanged();
        }
    }

    [Required(ErrorMessage = "Название тары обязательно")]
    public string PackagingTypeName
    {
        get => packagingTypeName;
        set
        {
            SetProperty(ref packagingTypeName, value);
            SavePackagingTypeCommand.NotifyCanExecuteChanged();
        }
    }
    [Range(0, int.MaxValue)]
    public decimal? PricePerSquareMeter
    {
        get => pricePerSquareMeter;
        set
        {
            SetProperty(ref pricePerSquareMeter, value);
            SavePackagingTypeCommand.NotifyCanExecuteChanged();
        }
    }
    [Range(0, int.MaxValue)]
    public decimal? PricePerSquareMeterOnWeeken
    {
        get => pricePerSquareMeterOnWeeken;
        set
        {
            SetProperty(ref pricePerSquareMeterOnWeeken, value);
            SavePackagingTypeCommand.NotifyCanExecuteChanged();
        }
    }


    public bool CanGoBack => navigationService.CanGoBack;
    public bool CanCreatePackagingType =>
        !string.IsNullOrWhiteSpace(PackagingTypeName) &&
        PricePerSquareMeter.HasValue &&
        PricePerSquareMeterOnWeeken.HasValue &&
        PricePerSquareMeter.Value > 0 &&
        PricePerSquareMeterOnWeeken > 0 &&
        !HasErrors;
    public bool CanDeleteOrEditPackagingType => SelectedPackagingType != null;
}
