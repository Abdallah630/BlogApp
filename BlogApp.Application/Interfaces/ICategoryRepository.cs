using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Interfaces
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category> CreateAsync(Category category);
	}
}
