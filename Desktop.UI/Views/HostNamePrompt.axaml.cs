using Avalonia.Controls;

namespace RaefTech.Desktop.UI.Views;

public partial class HostNamePrompt : Window
{
    public HostNamePrompt()
    {
        InitializeComponent();
    }

    public HostNamePromptViewModel? ViewModel => DataContext as HostNamePromptViewModel;
}
