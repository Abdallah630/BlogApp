namespace BlogApp.Domain.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<Post> Posts { get; set; } = new List<Post>();
	}
}