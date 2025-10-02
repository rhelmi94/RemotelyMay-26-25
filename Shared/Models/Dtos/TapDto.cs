﻿using System.Runtime.Serialization;

namespace RaefTech.Shared.Models.Dtos;

[DataContract]
public class TapDto
{

    [DataMember(Name = "PercentX")]
    public double PercentX { get; set; }

    [DataMember(Name = "PercentY")]
    public double PercentY { get; set; }
}
