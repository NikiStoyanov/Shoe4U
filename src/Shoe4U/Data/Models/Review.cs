﻿namespace Shoe4U.Data.Models;

public class Review
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public string Content { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }
}