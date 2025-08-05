using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using DDDLesson.Infrastructure.Repositories.PackagingTypeRepository;
using DDDLesson.WinUI3.Interfaces.Navigation;
using MediatR;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public partial class PackagingTypesViewModel : ObservableValidator
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;
    private readonly IPackagingTypeEntityRepository repository;
    private readonly INavigationService navigationService;

    public PackagingTypesViewModel(IMediator mediator, INavigationService navigationService, IMapper mapper, IPackagingTypeEntityRepository repository)
    {
        this.mediator = mediator;
        this.mapper = mapper;
        this.repository = repository;
        this.navigationService = navigationService;
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        this.repository.RepositoryChanged += async (s, e) => await GetPackagingTypesAsync();

        this.navigationService.CanGoBackChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(CanGoBack));
            GoBackCommand.NotifyCanExecuteChanged();
        };
    }
}
