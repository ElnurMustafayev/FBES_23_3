using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationsApp.Entities;

//[Table("People")]
public class User
{
    //[Key]
    public Guid MyPrimaryKey { get; set; }
    //[Required]
    //[Column("FirstName")]
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Password { get; set; }
    public string Mail { get; set; }
}