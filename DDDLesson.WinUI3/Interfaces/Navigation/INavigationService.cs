using Microsoft.UI.Xaml.Controls;
using System;

namespace DDDLesson.WinUI3.Interfaces.Navigation;

public interface INavigationService
{
    public void Initialize(Frame frame);
    void NavigateTo<T>(Action<T> initializeAction = null) where T : Page;
    void GoBack();
    bool CanGoBack {  get; }
    event EventHandler? CanGoBackChanged;
    public void NavigateToPage(Page page);
}
