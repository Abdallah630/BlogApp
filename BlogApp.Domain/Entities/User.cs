using BlogApp.Domain.Entities;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{
	public int Id { get; set; }
	public string UserName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string PasswordHash { get; set; } = string.Empty;
	public string Role { get; set; } = "Author";
	public ICollection<Post> Posts { get; set; } = new List<Post>();
	public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
