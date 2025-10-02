using RaefTech.Shared.Enums;
using RaefTech.Shared.Models;

namespace RaefTech.Server.Models.Messages;

public record PowerShellCompletionsMessage(PwshCommandCompletion Completion, CompletionIntent Intent);