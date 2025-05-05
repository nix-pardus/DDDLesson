using DDDLesson.WinUI3.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using DDDLesson.WinUI3.Interfaces.Navigation;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage(MainViewModel vm)
        {
            this.InitializeComponent();
            //DataContext = App.ServiceProvider?.GetRequiredService<MainViewModel>()
            //    ?? throw new InvalidOperationException("ServiceProvider not initialized.");
            DataContext = vm;
        }
    }
}
