using System.Threading.Tasks;

namespace RaefTech.Agent.Interfaces;

public interface IUpdater
{
    Task BeginChecking();
    Task CheckForUpdates();
    Task InstallLatestVersion();
}