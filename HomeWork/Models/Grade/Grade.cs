﻿namespace HomeWork.Models.Grade;
public class Grade
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal FixedAmount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
