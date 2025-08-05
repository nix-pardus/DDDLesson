using DDDLesson.WinUI3.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PackagingTypesPage : Page
    {
        public MainViewModel vm { get; }
        public PackagingTypesPage(MainViewModel vm)
        {
            this.InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            deleteFlyout.Hide();
        }
    }
}
