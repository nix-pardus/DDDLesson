using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using DDDLesson.Infrastructure.Repositories.WorkDayRepository;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using DDDLesson.Infrastructure.Repositories.WorkUnitRepository;
using DDDLesson.WinUI3.Interfaces.Navigation;
using MediatR;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM;

public partial class MainPageViewModel : ObservableValidator
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IWorkDayEntityRepository _workDayEntityRepository;
    private readonly IWorkUnitEntityRepository _workUnitEntityRepository;
    private readonly IWorkerEntityRepository _workerEntityRepository;
    private readonly IPackagingTypeEntityRepository _packagingTypeEntityRepository;
    private readonly INavigationService _navigationService;

    public MainPageViewModel(IMediator mediator, IMapper mapper, IWorkDayEntityRepository workDayEntityRepository, IWorkUnitEntityRepository workUnitEntityRepository, IWorkerEntityRepository workerEntityRepository, IPackagingTypeEntityRepository packagingTypeEntityRepository, INavigationService navigationService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _workDayEntityRepository = workDayEntityRepository;
        _workUnitEntityRepository = workUnitEntityRepository;
        _workerEntityRepository = workerEntityRepository;
        _packagingTypeEntityRepository = packagingTypeEntityRepository;
        _navigationService = navigationService;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        this._workDayEntityRepository.RepositoryChanged += async (s, e) => await GetWorkDaysOfMonthAsync();

        //this._navigationService.CanGoBackChanged += (s, e) =>
        //{
        //    OnPropertyChanged(nameof(CanGoBack));
        //    GoBackCommand.NotifyCanExecuteChanged();
        //};
    }
}
