using System.Collections.ObjectModel;
using System.Windows;

namespace codex_windows_desktop_client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ObservableCollection<string> _messages = new();

    public MainWindow()
    {
        InitializeComponent();
        ChatList.ItemsSource = _messages;
    }

    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            return;

        var userMessage = InputTextBox.Text.Trim();
        _messages.Add($"User: {userMessage}");
        InputTextBox.Clear();

        // Dummy response from Codex
        _messages.Add("Codex: This is a dummy response.");
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        using var dialog = new System.Windows.Forms.FolderBrowserDialog();
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            ProjectPathTextBox.Text = dialog.SelectedPath;
        }
    }
}

