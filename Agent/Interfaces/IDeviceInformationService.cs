using RaefTech.Shared.Dtos;
using System.Threading.Tasks;

namespace RaefTech.Agent.Interfaces;

public interface IDeviceInformationService
{
    Task<DeviceClientDto> CreateDevice(string deviceId, string orgId);
}
