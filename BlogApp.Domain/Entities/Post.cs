namespace BlogApp.Domain.Entities;

public class Post
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Content { get; set; } = string.Empty;
	public string Slug { get; set; } = string.Empty;
	public bool IsPublished { get; set; } = false;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public int AuthorId { get; set; }
	public User Author { get; set; } = null!;

	public int CategoryId { get; set; }
	public Category Category { get; set; } = null!;

	public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
}