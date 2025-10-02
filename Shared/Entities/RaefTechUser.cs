﻿using Microsoft.AspNetCore.Identity;
using RaefTech.Shared.Models;
using System.Text.Json.Serialization;

namespace RaefTech.Shared.Entities;

public class RaefTechUser : IdentityUser
{
    public ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public List<DeviceGroup> DeviceGroups { get; set; } = new();
    public bool IsAdministrator { get; set; }
    public bool IsServerAdmin { get; set; }

    [JsonIgnore]
    public Organization? Organization { get; set; }

    public string OrganizationID { get; set; } = null!;

    public List<SavedScript> SavedScripts { get; set; } = new();
    public List<ScriptSchedule> ScriptSchedules { get; set; } = new();

    public string? TempPassword { get; set; }

    public RaefTechUserOptions? UserOptions { get; set; }
}
