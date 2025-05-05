//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using DDDLesson.Domain.PackagingTypes.CreatePackagingType;
//using MediatR;
//using System.ComponentModel.DataAnnotations;
//using System.Threading;
//using System.Threading.Tasks;

//namespace DDDLesson.ApplicationWinUI3.Features.PackagingTypes.CreatePackagingType;

//public class CreatePackagingTypeViewModel : ObservableValidator
//{
//    private readonly IMediator mediator;
//    private string name = string.Empty;
//    private decimal pricePerSquareMeter;
//    private decimal pricePerSquareMeterOnWeeken;

//    [Required(ErrorMessage = "Название тары обязательно")]
//    public string Name
//    {
//        get => name;
//        set => SetProperty(ref name, value);
//    }
//    [Range(0, int.MaxValue)]
//    public decimal PricePerSquareMeter
//    {
//        get => pricePerSquareMeter;
//        set => SetProperty(ref pricePerSquareMeter, value);
//    }
//    [Range(0, int.MaxValue)]
//    public decimal PricePerSquareMeterOnWeeken
//    {
//        get => pricePerSquareMeterOnWeeken;
//        set => SetProperty(ref pricePerSquareMeterOnWeeken, value);
//    }

//    public bool CanCreatePackagingType => !string.IsNullOrWhiteSpace(Name) && !HasErrors;

//    public CreatePackagingTypeViewModel(IMediator mediator)
//    {
//        this.mediator = mediator;
//    }

//    [RelayCommand(IncludeCancelCommand = true, CanExecute = nameof(CanCreatePackagingType))]
//    public async Task CreatePackagingTypeAsync(CancellationToken cancellationToken)
//    {
//        await mediator.Send(new CreatePackagingTypeCommand()
//        {
//            Name = Name,
//            PricePerSquareMeter = PricePerSquareMeter,
//            PricePerSquareMeterOnWeeken = PricePerSquareMeterOnWeeken
//        }, cancellationToken);
//        Name = string.Empty;
//        PricePerSquareMeter = decimal.Zero;
//        PricePerSquareMeterOnWeeken = decimal.Zero;
//    }
//}
