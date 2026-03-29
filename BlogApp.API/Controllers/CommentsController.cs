using BlogApp.Application.DTOs;
using BlogApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Api.Controllers
{
	[ApiController]
	[Route("api/posts/{postId}/comments")]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentRepository _commentRepository;

		public CommentsController(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(int postId)
		{
			var comments = await _commentRepository.GetByPostIdAsync(postId);
			var result = comments.Select(c => new CommentDto
			{
				Id = c.Id,
				Body = c.Body,
				CreatedAt = c.CreatedAt,
				UserName = c.User.UserName
			});
			return Ok(result);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Create(int postId, [FromBody] string body)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

			var comment = new Comment
			{
				Body = body,
				PostId = postId,
				UserId = userId
			};

			var result = await _commentRepository.CreateAsync(comment);
			return Ok(result);
		}

		[Authorize]
		[HttpDelete("{commentId}")]
		public async Task<IActionResult> Delete(int postId, int commentId)
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
			var comment = await _commentRepository.GetByIdAsync(commentId);

			if (comment == null) return NotFound();

			if (comment.UserId != userId) return Forbid();

			await _commentRepository.DeleteAsync(commentId);
			return NoContent();
		}
	}
}
