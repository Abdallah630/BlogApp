using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.DTOs.Post
{
	public class CreatePostDto
	{
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int CategoryId { get; set; }
		public List<int> TagIds { get; set; } = new();
	}
}
