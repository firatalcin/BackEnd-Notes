﻿namespace BlogApp.Web.Entities;

public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Image { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; } 
}