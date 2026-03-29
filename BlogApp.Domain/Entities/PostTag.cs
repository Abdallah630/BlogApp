namespace BlogApp.Domain.Entities
{
	public class PostTag
	{
		public int PostId { get; set; }
		Post Post { get; set; } = null!;
		public int TagId { get; set; }
		public Tag Tag { get; set; } = null!;
	}
}