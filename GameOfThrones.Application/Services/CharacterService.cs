using System.Linq;
using GameOfThrones.Application.Interfaces;
using GameOfThrones.Domain.Entities;

namespace GameOfThrones.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            var allCharacters = await _repository.GetAllAsync();
            return allCharacters.ToList();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateCharacterAsync(Character character)
        {
            await _repository.AddAsync(character);
        }

        public async Task UpdateCharacterAsync(Character character)
        {
            await _repository.UpdateAsync(character);
        }

        public async Task DeleteCharacterAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Character>> SearchCharactersAsync(string name)
        {
            return await _repository.SearchAsync(name);
        }
    }
}
