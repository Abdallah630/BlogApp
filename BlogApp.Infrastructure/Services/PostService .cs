using BlogApp.Application.DTOs.Post;
using BlogApp.Application.Helpers;
using BlogApp.Application.Interfaces;
using BlogApp.Application.Service;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Infrastructure.Services
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _postRepository;

		public PostService(IPostRepository postRepository)
		{
			_postRepository = postRepository;
		}

		public async Task<PagedResult<PostDto>> GetAllAsync(PaginationParams pagination)
		{
			var result = await _postRepository.GetAllAsync(pagination);

			return new PagedResult<PostDto>
			{
				Data = result.Data.Select(p => new PostDto
				{
					Id = p.Id,
					Title = p.Title,
					Content = p.Content,
					Slug = p.Slug,
					IsPublished = p.IsPublished,
					CreatedAt = p.CreatedAt,
					AuthorName = p.Author.UserName,
					CategoryName = p.Category.Name,
					Tags = p.PostTags.Select(pt => pt.Tag.Name).ToList()
				}),
				TotalCount = result.TotalCount,
				PageNumber = result.PageNumber,
				PageSize = result.PageSize
			};

		}

		public async Task<PostDto?> GetBySlugAsync(string slug)
		{
			var post = await _postRepository.GetBySlugAsync(slug);
			if (post == null) return null;

			return new PostDto
			{
				Id = post.Id,
				Title = post.Title,
				Content = post.Content,
				Slug = post.Slug,
				IsPublished = post.IsPublished,
				CreatedAt = post.CreatedAt,
				AuthorName = post.Author.UserName,
				CategoryName = post.Category.Name,
				Tags = post.PostTags.Select(pt => pt.Tag.Name).ToList()
			};
		}

		public async Task<PostDto> CreateAsync(CreatePostDto dto, int authorId)
		{
			var post = new Post
			{
				Title = dto.Title,
				Content = dto.Content,
				Slug = dto.Title.ToLower().Replace(" ", "-"),
				AuthorId = authorId,
				CategoryId = dto.CategoryId,
				PostTags = dto.TagIds.Select(id => new PostTag { TagId = id }).ToList()
			};

			var created = await _postRepository.CreateAsync(post);
			return await GetBySlugAsync(created.Slug) ?? new PostDto();
		}

		public async Task UpdateAsync(int id, CreatePostDto dto)
		{
			var post = await _postRepository.GetBySlugAsync(id.ToString());
			if (post == null) return;

			await _postRepository.UpdateAsync(new Post
			{
				Id = id,
				Title = dto.Title,
				Content = dto.Content,
				Slug = dto.Title.ToLower().Replace(" ", "-"),
				CategoryId = dto.CategoryId
			});
		}

		public async Task DeleteAsync(int id)
		{
			await _postRepository.DeleteAsync(id);
		}
	}
}
