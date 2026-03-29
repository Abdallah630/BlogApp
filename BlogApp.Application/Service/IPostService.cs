using BlogApp.Application.DTOs.Post;
using BlogApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Service
{
	public interface IPostService
	{
		Task<PagedResult<PostDto>> GetAllAsync(PaginationParams pagination);
		Task<PostDto?> GetBySlugAsync(string slug);
		Task<PostDto> CreateAsync(CreatePostDto dto, int authorId);
		Task UpdateAsync(int id, CreatePostDto dto);
		Task DeleteAsync(int id);
	}
}
