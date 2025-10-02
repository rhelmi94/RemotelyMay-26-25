using RaefTech.Server.Enums;

namespace RaefTech.Server.Models.Messages;

public record DeviceCardStateChangedMessage(string DeviceId, DeviceCardState State);