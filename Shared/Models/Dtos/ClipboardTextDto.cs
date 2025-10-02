﻿using System.Runtime.Serialization;

namespace RaefTech.Shared.Models.Dtos;

[DataContract]
public class ClipboardTextDto
{
    public ClipboardTextDto(string clipboardText)
    {
        ClipboardText = clipboardText;
    }

    [DataMember(Name = "ClipboardText")]
    public string ClipboardText { get; }
}
