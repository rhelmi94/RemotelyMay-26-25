using RaefTech.Desktop.Shared.Abstractions;

namespace RaefTech.Desktop.Linux.Services;

public class AudioCapturerLinux : IAudioCapturer
{
#pragma warning disable CS0067
    public event EventHandler<byte[]>? AudioSampleReady;
#pragma warning restore

    public void ToggleAudio(bool toggleOn)
    {
        // Not implemented.
    }
}
