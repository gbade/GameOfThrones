using GameOfThrones.Application.Interfaces;
using GameOfThrones.Application.Services;
using GameOfThrones.Domain.Entities;
using Moq;

namespace GameOfThrones.Tests.Unit
{
    public class CharacterServiceTests
    {
        private Mock<ICharacterRepository> _characterRepositoryMock;
        private ICharacterService _characterService;

        [SetUp]
        public void Setup()
        {
            _characterRepositoryMock = new Mock<ICharacterRepository>();
            _characterService = new CharacterService(_characterRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllCharactersAsync_ShouldReturnAllCharacters()
        {
            // Arrange
            var characters = new List<Character>
            {
                new Character { Id = 1, CharacterName = "Jon Snow" },
                new Character { Id = 2, CharacterName = "Daenerys Targaryen" }
            };

            _characterRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(characters);

            // Act
            var result = await _characterService.GetAllCharactersAsync();

            // Assert
            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(characters.Count, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetCharacterByIdAsync_ShouldReturnCharacter_WhenCharacterExists()
        {
            // Arrange
            var character = new Character { Id = 1, CharacterName = "Jon Snow" };
            _characterRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(character);

            // Act
            var result = await _characterService.GetCharacterByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetCharacterByIdAsync_ShouldReturnNull_WhenCharacterDoesNotExist()
        {
            // Arrange
            var id = 1;
            _characterRepositoryMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync((Character)null);

            // Act
            var result = await _characterService.GetCharacterByIdAsync(id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task CreateCharacterAsync_ShouldCallRepositoryCreate()
        {
            // Arrange
            var character = new Character { CharacterName = "Jon Snow" };

            // Act
            await _characterService.CreateCharacterAsync(character);

            // Assert
            _characterRepositoryMock.Verify(repo => repo.AddAsync(character), Times.Once);
        }

        [Test]
        public async Task UpdateCharacterAsync_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var character = new Character { Id = 1, CharacterName = "Jon Snow" };

            // Act
            await _characterService.UpdateCharacterAsync(character);

            // Assert
            _characterRepositoryMock.Verify(repo => repo.UpdateAsync(character), Times.Once);
        }

        [Test]
        public async Task DeleteCharacterAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            var characterId = 1;

            // Act
            await _characterService.DeleteCharacterAsync(characterId);

            // Assert
            _characterRepositoryMock.Verify(repo => repo.DeleteAsync(characterId), Times.Once);
        }

        [Test]
        public async Task SearchCharactersAsync_ShouldReturnMatchingCharacters()
        {
            // Arrange
            var characters = new List<Character>
            {
                new Character { Id = 1, CharacterName = "Jon Snow" },
                new Character { Id = 2, CharacterName = "Daenerys Targaryen" }
            };

            _characterRepositoryMock.Setup(repo => repo.SearchAsync("Jon")).ReturnsAsync(characters);

            // Act
            var result = await _characterService.SearchCharactersAsync("Jon");

            // Assert
            Assert.That(result, Is.Not.Null.Or.Empty);
            Assert.That(result.Count, Is.EqualTo(characters.Count));
        }
    }
}
