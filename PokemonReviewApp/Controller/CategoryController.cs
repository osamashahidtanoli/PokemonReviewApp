using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]

        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);


        }

        [HttpGet("{catId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int catId)
        {
            if (!_categoryRepository.CategoryExists(catId))
                return NotFound();
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);

        }

        [HttpGet("pokemon/{catId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonsByCategory(int catId)
        {
            if (!_categoryRepository.CategoryExists(catId))
                return NotFound();
            var pokemon = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonsByCategory(catId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);


        }

    }
}
