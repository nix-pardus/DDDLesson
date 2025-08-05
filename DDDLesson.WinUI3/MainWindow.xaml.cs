using DDDLesson.WinUI3.Interfaces.Navigation;
using DDDLesson.WinUI3.Pages;
using DDDLesson.WinUI3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly Dictionary<string, Type> _pageTypes;
        private readonly Dictionary<string, ICommand> _commandCache = new();
        public MainWindow()
        {
            this.InitializeComponent();

            this.AppWindow.SetIcon("Assets/20.ico");

            _pageTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Page)))
                .ToDictionary(t => t.Name);

            MainViewModel = App.ServiceProvider?.GetRequiredService<MainViewModel>()
                ?? throw new InvalidOperationException("ServiceProvider not initialized.");

            var navService = App.ServiceProvider?.GetRequiredService<INavigationService>();
            navService?.Initialize(MainFrame);

            navService.CanGoBackChanged += (s, e) =>
            {
                NavView.IsBackEnabled = navService.CanGoBack;
            };

            navService?.NavigateTo<MainPage>();

            InitializeCommandCache();
        }

        public MainViewModel MainViewModel { get; }

        private void InitializeCommandCache()
        {
            var properties = typeof(MainViewModel).GetProperties();
            foreach(var property in properties)
            {
                if(typeof(ICommand).IsAssignableFrom(property.PropertyType))
                {
                    _commandCache[property.Name] = (ICommand)property.GetValue(MainViewModel);
                }
            }
        }

        private void NavView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            MainViewModel.GoBackCommand.Execute(null);
        }

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if(args.InvokedItemContainer is NavigationViewItem item && item.Tag is string commandName)
            {
                if(_commandCache.TryGetValue(commandName, out var command))
                {
                    command.Execute(null);
                }
            }
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.SelectedItem = NavView.MenuItems
                .OfType<NavigationViewItem>()
                .FirstOrDefault(item => item.Tag?.ToString() == "NavigateToMainCommand");
        }
    }
}
