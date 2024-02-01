// UserModel.cs
using System.ComponentModel.DataAnnotations;

public class UserModel
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
