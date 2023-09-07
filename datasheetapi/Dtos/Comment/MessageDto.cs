using System.ComponentModel.DataAnnotations;

namespace datasheetapi.Dtos;
public record MessageDto
{
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;
}
