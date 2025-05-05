using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using Windows.System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();


            MainViewModel = App.ServiceProvider?.GetRequiredService<MainViewModel>()
                ?? throw new InvalidOperationException("ServiceProvider not initialized.");
            MainStackPanel.DataContext = MainViewModel;

            var navService = App.ServiceProvider?.GetRequiredService<INavigationService>();
            navService?.Initialize(MainFrame);

            navService?.NavigateTo<MainPage>();

        }

        public MainViewModel MainViewModel { get; }

        private void TextBox_KeyDown(object sender, Microsoft.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter && MainViewModel.CreateWorker.CanCreateWorker)
            {
                MainViewModel.CreateWorker.CreateWorkerCommand.Execute(null);
                e.Handled = true;
            }
        }
    }
}
