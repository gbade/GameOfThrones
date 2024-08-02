using GameOfThrones.Domain.Entities;

namespace GameOfThrones.Application.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetByIdAsync(int id);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
        Task<IEnumerable<Character>> SearchAsync(string name);
    }
}
