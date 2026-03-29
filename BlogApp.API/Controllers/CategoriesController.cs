using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryRepository.GetAllAsync();
			return Ok(categories);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			var result = await _categoryRepository.CreateAsync(category);
			return Ok(result);
		}
	}
}
