using RaefTech.Desktop.Shared.Abstractions;
using RaefTech.Desktop.UI.Controls.Dialogs;
using Microsoft.Extensions.Logging;
using RaefTech.Desktop.Shared.Services;

namespace RaefTech.Desktop.UI.ViewModels;

public interface ISessionIndicatorWindowViewModel : IBrandedViewModelBase
{
    Task PromptForExit();
}
public class SessionIndicatorWindowViewModel : BrandedViewModelBase, ISessionIndicatorWindowViewModel
{
    private readonly IShutdownService _shutdownService;
    private readonly IDialogProvider _dialogProvider;

    public SessionIndicatorWindowViewModel(
        IBrandingProvider brandingProvider,
        IUiDispatcher dispatcher,
        IShutdownService shutdownService,
        IDialogProvider dialogProvider,
        ILogger<BrandedViewModelBase> logger)
        : base(brandingProvider, dispatcher, logger)
    {
        _shutdownService = shutdownService;
        _dialogProvider = dialogProvider;
    }

    public async Task PromptForExit()
    {
        var result = await _dialogProvider.Show("Stop the remote control session?", "Stop Session", MessageBoxType.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            await _shutdownService.Shutdown();
        }
    }
}
