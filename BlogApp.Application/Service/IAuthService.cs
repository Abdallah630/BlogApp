using BlogApp.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Service
{
	public interface IAuthService
	{
		Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
		Task<AuthResponseDto> LoginAsync(LoginDto dto);

	}
}
