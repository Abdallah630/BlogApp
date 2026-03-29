using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.DTOs.Post
{
	public class PostDto
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string Slug { get; set; } = string.Empty;
		public bool IsPublished { get; set; }
		public DateTime CreatedAt { get; set; }
		public string AuthorName { get; set; } = string.Empty;
		public string CategoryName { get; set; } = string.Empty;
		public List<string> Tags { get; set; } = new();
	}
}
