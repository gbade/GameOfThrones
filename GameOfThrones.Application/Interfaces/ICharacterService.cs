using GameOfThrones.Domain.Entities;

namespace GameOfThrones.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task CreateCharacterAsync(Character character);
        Task UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(int id);
        Task<IEnumerable<Character>> SearchCharactersAsync(string name);
    }
}
