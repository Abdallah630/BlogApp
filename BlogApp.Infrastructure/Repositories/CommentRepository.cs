using BlogApp.Application.Interfaces;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Infrastructure.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly AppDbContext _context;

		public CommentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
		{
			return await _context.Comments
				.Include(c => c.User)
				.Where(c => c.PostId == postId)
				.ToListAsync();
		}

		public async Task<Comment> CreateAsync(Comment comment)
		{
			_context.Comments.Add(comment);
			await _context.SaveChangesAsync();
			return comment;
		}

		public async Task DeleteAsync(int id)
		{
			var comment = await _context.Comments.FindAsync(id);
			if (comment != null)
			{
				_context.Comments.Remove(comment);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Comment?> GetByIdAsync(int id)
		{
			return await _context.Comments.FindAsync(id);
		}
	}
}
