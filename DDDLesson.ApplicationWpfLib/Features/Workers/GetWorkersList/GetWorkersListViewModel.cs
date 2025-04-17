using AutoMapper;
using DDDLesson.ApplicationWpfLib.Common;
using DDDLesson.ApplicationWpfLib.ViewModels.Workers.GetWorkersList;
using DDDLesson.Domain.Workers.GetWorkersList;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DDDLesson.ApplicationWpfLib.Features.Workers.GetWorkersList;

public class GetWorkersListViewModel : ViewModelBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private ObservableCollection<GetWorkersListResponseEntry> workers = new();

    public GetWorkersListViewModel(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        GetWorkersCommand = new RelayCommand(async () => await LoadWorkersAsync());
        LoadWorkersAsync().ConfigureAwait(false);
    }

    public ObservableCollection<GetWorkersListResponseEntry> Workers
    {
        get => workers;
        set
        {
            workers = value;
            OnPropertyChanged();
        }
    }

    public ICommand GetWorkersCommand { get; }

    public async Task LoadWorkersAsync()
    {
        var workers = await mediator.Send(new GetWorkersListQuery());
        Workers = mapper.Map<GetWorkersListResponse>(workers).Entries;
    }
}
