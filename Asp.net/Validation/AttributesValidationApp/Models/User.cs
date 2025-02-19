namespace ValidationApp.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "Name field deyer saxlamalidir")]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    [Range(0, 100)]
    [Required]
    public int? Age { get; set; }
}