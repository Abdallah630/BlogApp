using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Interfaces
{
	public interface ICommentRepository
	{
		Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
		Task<Comment?> GetByIdAsync(int id);
		Task<Comment> CreateAsync(Comment comment);
		Task DeleteAsync(int id);
	}
}
