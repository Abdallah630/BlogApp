using BlogApp.Application.Helpers;
using BlogApp.Domain.Entities;


namespace BlogApp.Application.Interfaces
{
	public interface IPostRepository
	{
		Task<PagedResult<Post>> GetAllAsync(PaginationParams pagination);
		Task<Post?> GetBySlugAsync(string slug);
		Task<Post> CreateAsync(Post post);
		Task UpdateAsync(Post post);
		Task DeleteAsync(int id);
	}
}
