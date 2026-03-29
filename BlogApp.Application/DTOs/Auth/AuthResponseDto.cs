using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.DTOs.Auth
{
	public class AuthResponseDto
	{
		public string Token { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
	}
}
