using System.ComponentModel.DataAnnotations;

namespace RaefTech.Shared.Entities;

public class KeyValueRecord
{
    [Key]
    public Guid Key { get; set; }
    public string? Value { get; set; }
}
