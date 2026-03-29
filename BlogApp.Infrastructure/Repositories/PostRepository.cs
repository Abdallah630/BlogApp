using BlogApp.Application.Helpers;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Infrastructure.Repositories
{
	public class PostRepository : IPostRepository
	{
		private readonly AppDbContext _context;

		public PostRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Post> CreateAsync(Post post)
		{
			_context.Posts.Add(post);
			await _context.SaveChangesAsync();
			return post;
		}

		public async Task DeleteAsync(int id)
		{
			var post = await _context.Posts.FindAsync(id);
			if (post != null)
			{
				_context.Posts.Remove(post);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<PagedResult<Post>> GetAllAsync(PaginationParams pagination)
		{
			var query = _context.Posts
		   .Include(p => p.Author)
		   .Include(p => p.Category)
		   .Include(p => p.PostTags)
			   .ThenInclude(pt => pt.Tag)
		   .AsQueryable();

			if (!string.IsNullOrEmpty(pagination.Search))
				query = query.Where(p => p.Title.Contains(pagination.Search));

			if (pagination.CategoryId.HasValue)
				query = query.Where(p => p.CategoryId == pagination.CategoryId);

			var totalCount = await query.CountAsync();

			var posts = await query
				.Skip((pagination.PageNumber - 1) * pagination.PageSize)
				.Take(pagination.PageSize)
				.ToListAsync();

			return new PagedResult<Post>
			{
				Data = posts,
				TotalCount = totalCount,
				PageNumber = pagination.PageNumber,
				PageSize = pagination.PageSize
			};
		}

		public async Task<Post?> GetBySlugAsync(string slug)
		{
			return await _context.Posts
						.Include(p => p.Author)
						.Include(p => p.Category)
						.FirstOrDefaultAsync(p => p.Slug == slug);
		}

		public async Task UpdateAsync(Post post)
		{
			_context.Posts.Update(post);
			await _context.SaveChangesAsync();
		}
	}
}
