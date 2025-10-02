﻿using System.Runtime.Serialization;

namespace RaefTech.Shared.Models.Dtos;

[DataContract]
public class MouseWheelDto
{

    [DataMember(Name = "DeltaX")]
    public double DeltaX { get; set; }

    [DataMember(Name = "DeltaY")]
    public double DeltaY { get; set; }
}
