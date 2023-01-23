using System.ComponentModel.DataAnnotations;


namespace TEST_IIS_API.Models;

public partial class Employee
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
}
