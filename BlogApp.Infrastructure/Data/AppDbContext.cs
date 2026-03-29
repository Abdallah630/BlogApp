using Azure;
using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) 
			: base(options) { }

		public DbSet<User> Users => Set<User>();
		public DbSet<Post> Posts => Set<Post>();
		public DbSet<Category> Categories => Set<Category>();
		public DbSet<Tag> Tags => Set<Tag>();
		public DbSet<PostTag> PostTags => Set<PostTag>();
		public DbSet<Comment> Comments => Set<Comment>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostTag>()
				.HasKey(pt => new { pt.PostId, pt.TagId });

	
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Post>()
				.HasOne(p => p.Author)
				.WithMany(u => u.Posts)
				.HasForeignKey(p => p.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
