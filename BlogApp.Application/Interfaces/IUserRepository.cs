using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Interfaces
{
	public interface IUserRepository
	{
		Task<User?> GetByEmailAsync(string email);
		Task<User?> GetByIdAsync(int id);
		Task<User> CreateAsync(User user);
	}
}
