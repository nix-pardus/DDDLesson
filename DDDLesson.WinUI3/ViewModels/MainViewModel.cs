using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels.MainPageVM;
using DDDLesson.WinUI3.ViewModels.PackagingTypes;
using DDDLesson.WinUI3.ViewModels.Workers;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;

namespace DDDLesson.WinUI3.ViewModels;

public partial class MainViewModel : ObservableValidator
{
    private readonly INavigationService _navigationService;
    private readonly Stack<Page> _navigationStack = new();
    public PackagingTypesViewModel PackagingTypesVM { get; }
    public WorkersViewModel WorkersVM { get; }
    public MainPageViewModel MainPageVM { get; }

    public MainViewModel
    (
        PackagingTypesViewModel packagingTypesVM,
        INavigationService navigationService,
        WorkersViewModel workersVM,
        MainPageViewModel mainPageVM)
    {
        PackagingTypesVM = packagingTypesVM;
        _navigationService = navigationService;
        WorkersVM = workersVM;
        MainPageVM = mainPageVM;
    }

    [RelayCommand]
    public void NavigateToMain() => _navigationService.NavigateTo<MainPage>();

    [RelayCommand]
    public void NavigateToPackagingTypesVM()
    {
        _navigationService.NavigateTo<PackagingTypesPage>(page =>
        {
            if(page.DataContext is MainViewModel mainVm)
            {
                mainVm.PackagingTypesVM.GetPackagingTypesCommand.Execute(mainVm);
            }
        });
    }
    
    [RelayCommand]
    public void NavigateToWorkersVM()
    {
        _navigationService.NavigateTo<WorkersPage>(page =>
        {
            if(page.DataContext is MainViewModel mainVm)
            {
                mainVm.WorkersVM.GetWorkersCommand.Execute(mainVm);
            }
        });
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
