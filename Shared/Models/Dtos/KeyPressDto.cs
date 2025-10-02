using System.Runtime.Serialization;

namespace RaefTech.Shared.Models.Dtos;

[DataContract]
public class KeyPressDto
{
    [DataMember(Name = "Key")]
    public string Key { get; set; } = string.Empty;
}
