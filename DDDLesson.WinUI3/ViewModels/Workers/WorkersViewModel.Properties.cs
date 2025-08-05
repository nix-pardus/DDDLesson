using CommunityToolkit.Mvvm.Input;
using DDDLesson.Domain.PackagingTypes.DeletePackagingType;
using DDDLesson.Domain.PackagingTypes.EditPackagingType;
using DDDLesson.WinUI3.ViewModels.Workers.Responses;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Popups;

namespace DDDLesson.WinUI3.ViewModels.Workers;

public partial class WorkersViewModel
{
    private ObservableCollection<GetWorkersListResponseEntry> workersList;
    private GetWorkersListResponseEntry selectedWorker;
    private string name = string.Empty;
    private bool isInOurShift;
    private bool isPaneOpen;
    private bool isEditMode;

    public bool IsInOurShift
    {
        get => isInOurShift;
        set
        {
            SetProperty(ref isInOurShift, value);
        }
    }

    public bool IsPaneOpen
    {
        get => isPaneOpen;
        set
        {
            try
            {
                SetProperty(ref isPaneOpen, value);
            }
            catch(Exception ex)
            {
                ShowError("Pane error" ,ex);
            }
        }
    }

    public ObservableCollection<GetWorkersListResponseEntry> WorkersList
    {
        get => workersList;
        set
        {
            SetProperty(ref workersList, value);
        }
    }

    public GetWorkersListResponseEntry SelectedWorker
    {
        get => selectedWorker;
        set
        {
            SetProperty(ref selectedWorker, value);
            OnPropertyChanged(nameof(CanDeleteOrEditWorker));
            DeleteWorkerCommand.NotifyCanExecuteChanged();
            EditWorkerCommand.NotifyCanExecuteChanged();
        }
    }

    [Required(ErrorMessage = "Имя упаковщика обязательно")]
    public string WorkerName
    {
        get => name;
        set
        {
            SetProperty(ref name, value);
            SaveWorkerCommand.NotifyCanExecuteChanged();
        }
    }

    public bool CanGoBack => navigationService.CanGoBack;

    public bool CanCreateWorker => 
        !string.IsNullOrWhiteSpace(WorkerName) &&
        !HasErrors;

    public bool CanDeleteOrEditWorker => SelectedWorker != null;

    private async void ShowError(string title ,Exception exception)
    {
        ContentDialog contentDialog = new ContentDialog
        {
            Title = title,
            Content = exception.Message,
            CloseButtonText = "Ok"
        };
        ContentDialogResult result = await contentDialog.ShowAsync();
    }
}
