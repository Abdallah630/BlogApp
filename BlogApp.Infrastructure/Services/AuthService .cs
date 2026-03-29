using BlogApp.Application.DTOs.Auth;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Infrastructure.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;

		public AuthService(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_configuration = configuration;
		}

		public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
		{
			var user = new User
			{
				UserName = dto.Username,
				Email = dto.Email,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
			};

			await _userRepository.CreateAsync(user);
			return GenerateToken(user);
		}

		public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
		{
			var user = await _userRepository.GetByEmailAsync(dto.Email);

			if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
				throw new Exception("Invalid credentials");

			return GenerateToken(user);
		}

		private AuthResponseDto GenerateToken(User user)
		{
			var claims = new[]
			{
		new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
		new Claim(ClaimTypes.Email, user.Email),
		new Claim(ClaimTypes.Role, user.Role),
	};

			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"]!));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				claims: claims,
				expires: DateTime.UtcNow.AddDays(
					double.Parse(_configuration["JWT:DurationIndDays"] ?? "1")),
				signingCredentials: creds
			);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return new AuthResponseDto
			{
				Token = tokenString,
				UserName = user.UserName,
				Role = user.Role
			};
		}
	}
	}
	
