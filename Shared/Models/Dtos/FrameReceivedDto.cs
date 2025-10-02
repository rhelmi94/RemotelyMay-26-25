using System.Runtime.Serialization;

namespace RaefTech.Shared.Models.Dtos;

[DataContract]
public class FrameReceivedDto
{
    [DataMember]
    public long Timestamp { get; set; }
}
