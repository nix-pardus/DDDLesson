using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlsCollection;

public sealed partial class FloatingTextBox : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(FloatingTextBox),
            new PropertyMetadata("", OnTextPropertyChanged));

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register("Placeholder", typeof(string), typeof(FloatingTextBox),
            new PropertyMetadata("", OnPlaceholderPropertyChanged));

    public static readonly DependencyProperty IsNumericProperty =
        DependencyProperty.Register("IsNumeric", typeof(bool), typeof(FloatingTextBox),
            new PropertyMetadata(false));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsNumeric
    {
        get => (bool)GetValue(IsNumericProperty);
        set => SetValue(IsNumericProperty, value);
    }

    public FloatingTextBox()
    {
        this.InitializeComponent();
        PlaceholderText.Text = Placeholder;
        UpdateVisualState(false);
    }

    private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FloatingTextBox control)
        {
            control.InputTextBox.Text = e.NewValue?.ToString();
            control.UpdateVisualState(control.InputTextBox.FocusState != FocusState.Unfocused || !string.IsNullOrEmpty(control.InputTextBox.Text));
        }
    }

    private static void OnPlaceholderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FloatingTextBox control)
        {
            control.PlaceholderText.Text = e.NewValue?.ToString();
        }
    }

    private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        Text = InputTextBox.Text;
        UpdateVisualState(InputTextBox.FocusState != FocusState.Unfocused || !string.IsNullOrEmpty(InputTextBox.Text));
    }

    private void InputTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        InputBorder.BorderBrush = (Brush)Application.Current.Resources["TextBoxBorderThemeBrush"];
        UpdateVisualState(true);
    }

    private void InputTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        InputBorder.BorderBrush = (Brush)Application.Current.Resources["TextControlBorderBrush"];
        UpdateVisualState(!string.IsNullOrEmpty(InputTextBox.Text));
    }

    private void PlaceholderText_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        InputTextBox.Focus(FocusState.Programmatic);
    }

    private void UpdateVisualState(bool shouldFloat)
    {
        VisualStateManager.GoToState(this, shouldFloat ? "Floating" : "Normal", true);
    }

    private void InputTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
    {
        if (IsNumeric)
        {
            args.Cancel = !args.NewText.All(c => 
            char.IsDigit(c) ||
            c == '.' ||
            c == ',' ||
            c == '\b');
        }
    }
}
