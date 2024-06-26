﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachConnect.DataAccess.Entities;

public readonly record struct UserId(Guid userId)
{ 
    public static UserId NewId => new UserId(Guid.NewGuid());
    public static UserId Empty => new UserId(Guid.Empty);
};

public class User : Login
{
    [Key]
    public UserId Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string HashedPassword { get; set; } = string.Empty;

    [Required]
    public string Salt { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; init; }

    [Required]
    public DateTime Updated { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
