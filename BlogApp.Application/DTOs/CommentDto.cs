using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DTOs
{
	public class CommentDto
	{
		public int Id { get; set; }
		public string Body { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; }
		public string UserName { get; set; } = string.Empty;
	}
}
