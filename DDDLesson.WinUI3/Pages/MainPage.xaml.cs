using DDDLesson.WinUI3.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using DDDLesson.WinUI3.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml;
using Windows.Foundation.Metadata;
using System.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DDDLesson.WinUI3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _storedItem;

        public MainPage(MainViewModel vm)
        {
            this.InitializeComponent();
            DataContext = vm;

            var items = new List<int>();
            for (int i = 0; i < 31; i++)
            {
                items.Add(i);
            }

            //collection.ItemsSource = items;

        }

        private async void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("backwardsAnimation", destinationElement);
            SmokeGrid.Children.Remove(destinationElement);

            // Collapse the smoke when the animation completes.
            animation.Completed += Animation_Completed;

            // If the connected item appears outside the viewport, scroll it into view.
            collection.ScrollIntoView(_storedItem, ScrollIntoViewAlignment.Default);
            collection.UpdateLayout();

            // Use the Direct configuration to go back (if the API is available).
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                animation.Configuration = new DirectConnectedAnimationConfiguration();
            }

            // Play the second connected animation.
            await collection.TryStartConnectedAnimationAsync(animation, _storedItem, "connectedElement");
        }

        private void Animation_Completed(ConnectedAnimation sender, object args)
        {
            SmokeGrid.Visibility = Visibility.Collapsed;
            SmokeGrid.Children.Add(destinationElement);
        }

        private void TipsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConnectedAnimation animation = null;

            // Get the collection item corresponding to the clicked item.
            if (collection.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                _storedItem = Convert.ToInt32(container.Content);

                // Prepare the connected animation.
                // Notice that the stored item is passed in, as well as the name of the connected element.
                // The animation will actually start on the Detailed info page.
                animation = collection.PrepareConnectedAnimation("forwardAnimation", _storedItem, "connectedElement");

            }

            SmokeGrid.Visibility = Visibility.Visible;

            animation.TryStart(destinationElement);
        }
    }
}
