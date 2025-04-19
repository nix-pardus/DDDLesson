using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDDLesson.Domain.Workers.GetWorkersList;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;

public partial class GetWorkerListViewModel : ObservableValidator
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IWorkerEntityRepository repository;
    private ObservableCollection<GetWorkersListResponseEntry> workersList;

    public GetWorkerListViewModel(IMediator mediator, IMapper mapper, IWorkerEntityRepository repository)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        GetWorkersCommand.Execute(this);
        this.repository = repository;
        this.repository.RepositoryChanged += async (s, e) => await GetWorkersAsync();
    }

    public ObservableCollection<GetWorkersListResponseEntry> WorkersList
    {
        get => workersList;
        set
        {
            SetProperty(ref workersList, value);
        }
    }

    [RelayCommand]
    public async Task GetWorkersAsync()
    {
        var response = await mediator.Send(new GetWorkersListQuery());
        WorkersList = mapper.Map<GetWorkersListResponse>(response).Entries;
    }


}
