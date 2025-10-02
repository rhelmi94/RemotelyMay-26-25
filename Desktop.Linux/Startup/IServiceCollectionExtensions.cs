using RaefTech.Desktop.Shared.Abstractions;
using RaefTech.Desktop.Shared.Startup;
using Microsoft.Extensions.DependencyInjection;
using RaefTech.Desktop.Linux.Services;
using RaefTech.Desktop.UI.Services;
using RaefTech.Desktop.UI.Startup;

namespace RaefTech.Desktop.Linux.Startup;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds Linux and cross-platform remote control services to the service collection.
    /// All methods on <see cref="IRemoteControlClientBuilder"/> must be called to register
    /// required services.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="clientConfig"></param>
    public static void AddRemoteControlLinux(this IServiceCollection services)
    {
        services.AddRemoteControlXplat();
        services.AddRemoteControlUi();

        services.AddSingleton<IAppStartup, AppStartup>();
        services.AddSingleton<ICursorIconWatcher, CursorIconWatcherLinux>();
        services.AddSingleton<IKeyboardMouseInput, KeyboardMouseInputLinux>();
        services.AddSingleton<IClipboardService, ClipboardService>();
        services.AddSingleton<IAudioCapturer, AudioCapturerLinux>();
        services.AddTransient<IScreenCapturer, ScreenCapturerLinux>();
        services.AddScoped<IFileTransferService, FileTransferServiceLinux>();
        services.AddSingleton<ISessionIndicator, SessionIndicator>();
        services.AddSingleton<IShutdownService, ShutdownServiceLinux>();
    }
}
