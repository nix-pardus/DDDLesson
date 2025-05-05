using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.UnhandledException += (sender, e) =>
            {
                Debug.WriteLine($"UNHANDLED EXCEPTION: {e.Exception}");
            };
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Debug.WriteLine($"TASK EXCEPTOPN: {e.Exception}");
            };

            this.InitializeComponent();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAplicationServices();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {


            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window? m_window;
    }
}
