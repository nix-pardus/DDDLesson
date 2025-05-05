using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels.PackagingTypes;
using DDDLesson.WinUI3.ViewModels.Workers.CreateWorker;
using DDDLesson.WinUI3.ViewModels.Workers.DeleteWorker;
using DDDLesson.WinUI3.ViewModels.Workers.GetWorkersList;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace DDDLesson.WinUI3.ViewModels;

public partial class MainViewModel : ObservableValidator
{
    private readonly INavigationService _navigationService;
    private readonly Stack<Page> _navigationStack = new();
    public CreateWorkerViewModel CreateWorker { get; }
    public GetWorkerListViewModel GetWorkerList { get; }
    public DeleteWorkerViewModel DeleteWorker { get; }
    public PackagingTypesViewModel PackagingTypesVM { get; }


    public MainViewModel
    (
        CreateWorkerViewModel createWorker,
        GetWorkerListViewModel getWorkerList,
        DeleteWorkerViewModel deleteWorker,
        PackagingTypesViewModel packagingTypesVM,
        INavigationService navigationService)
    {
        CreateWorker = createWorker;
        GetWorkerList = getWorkerList;
        DeleteWorker = deleteWorker;
        PackagingTypesVM = packagingTypesVM;
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateToPackagingTypesVM()
    {
        _navigationService.NavigateTo<PackagingTypesPage>();
    }

    [RelayCommand(CanExecute = nameof(CanGoBack))]
    public void GoBack()
    {
        if(!CanGoBack) return;

        _navigationStack.Pop();
        var previousPage = _navigationStack.Peek();
        _navigationService.NavigateToPage(previousPage);
        GoBackCommand.NotifyCanExecuteChanged();
    }

    public void AddToNavigationStack(Page page)
    {
        _navigationStack.Push(page);
        GoBackCommand.NotifyCanExecuteChanged();
    }

    public bool CanGoBack => _navigationStack.Count > 1;
}
