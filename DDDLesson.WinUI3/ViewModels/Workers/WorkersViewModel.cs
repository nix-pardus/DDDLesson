using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using DDDLesson.WinUI3.Interfaces.Navigation;
using MediatR;

namespace DDDLesson.WinUI3.ViewModels.Workers;

public partial class WorkersViewModel : ObservableValidator
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IWorkerEntityRepository repository;
    private readonly INavigationService navigationService;

    public WorkersViewModel(IMediator mediator, IMapper mapper, IWorkerEntityRepository repository, INavigationService navigationService)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.repository = repository;
        this.navigationService = navigationService;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        this.repository.RepositoryChanged += async (s, e) => await GetWorkersAsync();

        this.navigationService.CanGoBackChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(CanGoBack));
            GoBackCommand.NotifyCanExecuteChanged();
        };
    }
}
