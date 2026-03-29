using BlogApp.Application.DTOs.Post;
using BlogApp.Application.Helpers;
using BlogApp.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
	private readonly IPostService _postService;

	public PostsController(IPostService postService)
	{
		_postService = postService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery]PaginationParams pagination)
	{
		var posts = await _postService.GetAllAsync(pagination);
		return Ok(posts);
	}

	[HttpGet("{slug}")]
	public async Task<IActionResult> GetBySlug(string slug)
	{
		var post = await _postService.GetBySlugAsync(slug);
		if (post == null) return NotFound();
		return Ok(post);
	}

	[Authorize]
	[HttpPost]
	public async Task<IActionResult> Create(CreatePostDto dto)
	{
		var authorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
		var post = await _postService.CreateAsync(dto, authorId);
		return Ok(post);
	}

	[Authorize]
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, CreatePostDto dto)
	{
		await _postService.UpdateAsync(id, dto);
		return NoContent();
	}

	[Authorize(Roles = "Admin")]
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		await _postService.DeleteAsync(id);
		return NoContent();
	}
}