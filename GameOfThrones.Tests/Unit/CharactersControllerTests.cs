using GameOfThrones.API.Controllers;
using GameOfThrones.Application.Interfaces;
using GameOfThrones.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;

namespace GameOfThrones.Tests.Unit
{
    public class CharactersControllerTests
    {
        private Mock<ICharacterService> _characterServiceMock;
        private Mock<ILogger> _loggerMock;
        private CharactersController _controller;

        [SetUp]
        public void Setup()
        {
            _characterServiceMock = new Mock<ICharacterService>();
            _loggerMock = new Mock<ILogger>();
            _controller = new CharactersController(_characterServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetCharacter_ShouldLogError_WhenCharacterNotFound()
        {
            // Arrange
            int characterId = 1;
            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync((Character)null);

            // Act
            var result = await _controller.GetCharacter(characterId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);

            //Verify
            _loggerMock.Verify(logger => 
                logger.Error("Character with the id - {Id} was not found", characterId), 
                Times.Once);
        }

        [Test]
        public async Task CreateCharacter_ShouldLogInformation_WhenCharacterCreated()
        {
            // Arrange
            var character = new Character { CharacterName = "Jon Snow" };
            _characterServiceMock.Setup(service => service.CreateCharacterAsync(character)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateCharacter(character);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);

            //Verify
            _loggerMock.Verify(logger => 
                logger.Information("Character data successfully created - {@Character}", character), 
                Times.Once);
        }

        [Test]
        public async Task CreateCharacter_ShouldLogError_WhenExceptionThrown()
        {
            // Arrange
            var character = new Character { Id = 1, CharacterName = "Jon Snow" };
            var exception = new Exception("Test exception");
            _characterServiceMock.Setup(service => service.CreateCharacterAsync(character)).ThrowsAsync(exception);

            // Act
            var result = await _controller.CreateCharacter(character);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result.Result);
            var objectResult = result.Result as ObjectResult;
            Assert.That(objectResult?.StatusCode, Is.EqualTo(500));

            //Verify
            _loggerMock.Verify(logger => 
                logger.Error(exception, "An error occurred while creating the character - {@Character}", character), 
                Times.Once);
        }

        [Test]
        public async Task GetCharacters_ShouldReturnOkResult_WithListOfCharacters()
        {
            // Arrange
            var okStatusCode = System.Net.HttpStatusCode.OK;
            var characters = new List<Character> 
            { 
                new Character { CharacterName = "Jon Snow" }, 
                new Character { CharacterName = "Daenerys Targaryen" } 
            };
            _characterServiceMock.Setup(service => service.GetAllCharactersAsync()).ReturnsAsync(characters);

            // Act
            var result = await _controller.GetCharacters();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.That(okResult?.StatusCode, Is.EqualTo((int)okStatusCode));
            Assert.That(characters, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetCharacter_ShouldReturnResult_WithCharacterData() 
        {
            // Arrange
            var characterId = 2;
            var okStatusCode = System.Net.HttpStatusCode.OK;
            var expectedCharacter = new Character { CharacterName = "Stannis Baratheon" };
            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync(expectedCharacter);

            // Act
            var result = await _controller.GetCharacter(characterId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;

            Assert.That(okResult?.StatusCode, Is.EqualTo((int)okStatusCode));
            Assert.That(okResult.Value, Is.EqualTo(expectedCharacter));
        }

        [Test]
        public async Task GetCharacter_CharacterNotFound_ShouldReturnNotFound()
        {
            var characterId = 2;
            var notFoundStatusCode = System.Net.HttpStatusCode.NotFound;
            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync((Character)null);

            // Act
            var result = await _controller.GetCharacter(characterId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
            var notFoundResult = result.Result as NotFoundResult;
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo((int)notFoundStatusCode));
            _loggerMock.Verify(logger =>
                logger.Error("Character with the id - {Id} was not found", characterId),
                Times.Once);
        }

        [Test]
        public async Task UpdateCharacter_ShouldReturnNoContent_WhenCharacterUpdated()
        {
            // Arrange
            var characterId = 1;
            var character = new Character { CharacterName = "Robb Stark" };
            var expectedCharacter = new Character { CharacterName = "Jon Snow" };

            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync(expectedCharacter);
            _characterServiceMock.Setup(service => service.UpdateCharacterAsync(character)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateCharacter(characterId, character);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task UpdateCharacter_ShouldReturnNotFound_WhenCharacterDoesNotExist()
        {
            // Arrange
            var characterId = 9999;
            var character = new Character { CharacterName = "Jon Snow" };

            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync((Character)null);

            // Act
            var result = await _controller.UpdateCharacter(characterId, character);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
            _loggerMock.Verify(logger =>
                logger.Error("Character with the id - {Id} was not found", characterId),
                Times.Once);
        }

        [Test]
        public async Task DeleteCharacter_ShouldReturnNoContent_WhenCharacterDeleted()
        {
            // Arrange
            int characterId = 2;
            var expectedCharacter = new Character { CharacterName = "Stannis Baratheon" };
            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync(expectedCharacter);
            _characterServiceMock.Setup(service => service.DeleteCharacterAsync(characterId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteCharacter(characterId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DeleteCharacter_ShouldReturnNotFound_WhenCharacterDoesNotExist()
        {
            // Arrange
            int characterId = 9999;
            _characterServiceMock.Setup(service => service.GetCharacterByIdAsync(characterId)).ReturnsAsync((Character)null);

            // Act
            var result = await _controller.DeleteCharacter(characterId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
            _loggerMock.Verify(logger =>
                logger.Error("Character with the id - {Id} was not found", characterId),
                Times.Once);
        }
    }
}
