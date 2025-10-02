﻿using System.Text.Json;

namespace RaefTech.Shared.Utilities;

public class JsonSerializerHelper
{
    public static JsonSerializerOptions IndentedOptions { get; } = new JsonSerializerOptions() { WriteIndented = true };
    public static JsonSerializerOptions CaseInsensitiveOptions { get; } = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
}
