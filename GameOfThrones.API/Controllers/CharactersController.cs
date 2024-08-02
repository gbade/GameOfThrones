using GameOfThrones.Application.Interfaces;
using GameOfThrones.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GameOfThrones.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly Serilog.ILogger _logger;

        public CharactersController(ICharacterService characterService, Serilog.ILogger logger)
        {
            _characterService = characterService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                _logger.Error("Character with the id - {Id} was not found", id);
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            try
            {
                await _characterService.CreateCharacterAsync(character);
                _logger.Information("Character data successfully created - {@Character}", character);
                return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while creating the character - {@Character}", character);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, Character model)
        {
            try 
            {
                var character = await _characterService.GetCharacterByIdAsync(id);
                if (character == null) 
                {
                    _logger.Error("Character with the id - {Id} was not found", id);
                    return NotFound();
                }

                await _characterService.UpdateCharacterAsync(model);
                return NoContent();
            }
            catch (Exception ex) 
            {
                _logger.Error(ex, "An error occurred while updating the character - {@Character}", model);
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _characterService.GetCharacterByIdAsync(id);
            if (character == null)
            {
                _logger.Error("Character with the id - {Id} was not found", id);
                return NotFound();
            }

            await _characterService.DeleteCharacterAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Character>>> SearchCharacters(string name)
        {
            var characters = await _characterService.SearchCharactersAsync(name);
            return Ok(characters);
        }
    }
}
