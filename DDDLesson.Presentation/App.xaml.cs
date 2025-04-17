using AutoMapper;
using DDDLesson.ApplicationWpfLib;
using DDDLesson.ApplicationWpfLib.Features.Workers.CreateWorker;
using DDDLesson.ApplicationWpfLib.Features.Workers.GetWorkersList;
using DDDLesson.ApplicationWpfLib.ViewModels.Workers;
using DDDLesson.Domain;
using DDDLesson.Domain.Workers.CreateWorker;
using DDDLesson.Infrastructure.Persistence;
using DDDLesson.Infrastructure.Repositories.WorkerRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;


namespace DDDLesson.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddApplicationServices();

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
