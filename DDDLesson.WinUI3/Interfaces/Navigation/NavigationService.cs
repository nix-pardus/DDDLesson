using DDDLesson.WinUI3.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using System;

namespace DDDLesson.WinUI3.Interfaces.Navigation;

public class NavigationService : INavigationService
{
    private Frame _frame;
    private MainViewModel _mainViewModel;
    public event EventHandler? CanGoBackChanged;

    public void Initialize(Frame frame)
    {
        _frame = frame;
        _frame.Navigated += (s, e) => UpdateCanGoBack();
    }

    public bool CanGoBack => _frame?.CanGoBack ?? false;

    public void GoBack()
    {
        if (!CanGoBack) return;
        _frame.GoBack();
        UpdateCanGoBack();
    }

    public void NavigateTo<T>() where T : Page
    {
        if (_frame == null)
        {
            throw new InvalidOperationException("Frame не инизиализирован.");
        }
        var page = App.ServiceProvider.GetRequiredService<T>();
        _frame.Content = page;
        _mainViewModel = App.ServiceProvider.GetRequiredService<MainViewModel>();
        _mainViewModel.AddToNavigationStack(page);
    }

    public void NavigateToPage(Page page)
    {
        if (_frame == null) return;
        _frame.Content = page;
    }

    private void UpdateCanGoBack()
    {
        CanGoBackChanged?.Invoke(this, EventArgs.Empty);
    }
}
