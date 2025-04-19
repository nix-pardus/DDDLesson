using DDDLesson.ApplicationWinUI3;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

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
        }

        public MainViewModel MainViewModel { get; }
    }
}
