using GameOfThrones.API;
using Microsoft.AspNetCore.Mvc.Testing;
using GameOfThrones.Domain.Entities;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;

namespace GameOfThrones.Tests.Integration
{
    public class CharactersControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [Test]
        public async Task GetCharacters_ShouldReturnOkResponse()
        {
            // Act
            var response = await _client.GetAsync("/api/characters");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseString);
        }

        [Test]
        public async Task CreateCharacter_ShouldReturnCreatedResponse()
        {
            // Arrange
            var character = new Character
            {
                CharacterName = "Jon Snow",
                HouseName = "Stark",
                Royal = false,
                Parents = new List<string> { "Lyanna Stark", "Rhaegar Targaryen" },
                Siblings = new List<string> { "Robb Stark", "Sansa Stark", "Arya Stark", "Bran Stark", "Rickon Stark" },
                KilledBy = new List<string>(),
                Killed = new List<string> { "Qhorin Halfhand", "Karl Tanner", "Othell Yarwyck", "Alliser Thorne", "Olly" },
                Nickname = "The Bastard of Winterfell",
                CharacterImageThumb = "https://example.com/images/jon_snow_thumb.jpg",
                CharacterImageFull = "https://example.com/images/jon_snow_full.jpg",
                CharacterLink = "https://gameofthrones.fandom.com/wiki/Jon_Snow",
                ActorName = "Kit Harington",
                ActorLink = "https://en.wikipedia.org/wiki/Kit_Harington"
            };
            var content = new StringContent(JsonSerializer.Serialize(character), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/characters", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var createdCharacter = JsonSerializer.Deserialize<Character>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.That(createdCharacter, Is.Not.Null);
            Assert.That(character.CharacterName, Is.EqualTo(createdCharacter.CharacterName));
        }

        [Test]
        public async Task CreateCharacter_ShouldThrowExceptionInternalServerError() 
        {
            //Arrange
            var internalServerErrorStatus = System.Net.HttpStatusCode.InternalServerError;

            var character = new Character
            {
                Id = 120,
                CharacterName = "Jon Snow",
                HouseName = "Stark",
                Royal = false,
                Parents = new List<string> { "Lyanna Stark", "Rhaegar Targaryen" },
                Siblings = new List<string> { "Robb Stark", "Sansa Stark", "Arya Stark", "Bran Stark", "Rickon Stark" }
            };
            var content = new StringContent(JsonSerializer.Serialize(character), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/characters", content);

            // Assert
            Assert.That(internalServerErrorStatus, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task GetCharacter_ValidId_ShouldReturnOkResponse()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _client.GetAsync($"/api/characters/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.That(responseString, Is.Not.Empty);
        }

        [Test]
        public async Task GetCharacter_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var notFoundStatus = System.Net.HttpStatusCode.NotFound;

            // Act
            var response = await _client.GetAsync("/api/characters/9999");

            // Assert
            Assert.That(notFoundStatus, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task UpdateCharacter_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var character = new Character { CharacterName = "Update Test Character" };
            var createResponse = await _client.PostAsJsonAsync("/api/characters", character);
            createResponse.EnsureSuccessStatusCode();
            var createdCharacter = await createResponse.Content.ReadFromJsonAsync<Character>();

            var updateName = new Character { CharacterName = "Updated Character" };
            

            // Act
            var updateResponse = await _client.PutAsJsonAsync($"/api/characters/{createdCharacter?.Id}", updateName);

            // Assert
            updateResponse.EnsureSuccessStatusCode();
            Assert.That(updateResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));

            // Verify update
            var getResponse = await _client.GetAsync($"/api/characters/{createdCharacter?.Id}");
            var updatedCharacter = await getResponse.Content.ReadFromJsonAsync<Character>();
            Assert.That(updatedCharacter?.CharacterName, Is.EqualTo(createdCharacter?.CharacterName));
        }

        [Test]
        public async Task UpdateCharacter_ThrowException_ShouldReturnInternalServerError() 
        {
            // Arrange
            var internalServerErrorStatus = System.Net.HttpStatusCode.InternalServerError;

            var character = new Character { CharacterName = "Update Test Character" };
            var createResponse = await _client.PostAsJsonAsync("/api/characters", character);
            createResponse.EnsureSuccessStatusCode();
            var createdCharacter = await createResponse.Content.ReadFromJsonAsync<Character>();

            if (createdCharacter != null)
            {
                createdCharacter.CharacterName = "Updated Character Name";
            }

            // Act
            var updateResponse = await _client.PutAsJsonAsync($"/api/characters/{createdCharacter?.Id}", createdCharacter);

            // Assert
            Assert.That(internalServerErrorStatus, Is.EqualTo(updateResponse.StatusCode));
        }

        [Test]
        public async Task UpdateCharacter_InvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var character = new Character
            {
                CharacterName = "Jon Snow",
                HouseName = "Stark",
                Royal = true,
                Parents = new List<string> { "Lyanna Stark", "Rhaegar Targaryen" },
                Siblings = new List<string> { "Robb Stark", "Sansa Stark", "Arya Stark", "Bran Stark", "Rickon Stark" },
                KilledBy = new List<string>(),
                Killed = new List<string> { "Qhorin Halfhand", "Karl Tanner", "Othell Yarwyck", "Alliser Thorne", "Olly" },
                Nickname = "The Bastard of Winterfell",
                CharacterImageThumb = "https://example.com/images/jon_snow_thumb.jpg",
                CharacterImageFull = "https://example.com/images/jon_snow_full.jpg",
                CharacterLink = "https://gameofthrones.fandom.com/wiki/Jon_Snow",
                ActorName = "Kit Harington",
                ActorLink = "https://en.wikipedia.org/wiki/Kit_Harington"
            };

            // Act
            var response = await _client.PutAsJsonAsync($"/api/characters/99999", character);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteCharacter_ValidId_ShouldReturnNoContent()
        {
            // Arrange
            var character = new Character { CharacterName = "Delete Test Character" };
            var createResponse = await _client.PostAsJsonAsync("/api/characters", character);
            createResponse.EnsureSuccessStatusCode();
            var createdCharacter = await createResponse.Content.ReadFromJsonAsync<Character>();

            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/characters/{createdCharacter?.Id}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));

            // Verify deletion
            var getResponse = await _client.GetAsync($"/api/characters/{createdCharacter?.Id}");
            Assert.That(getResponse.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        public async Task DeleteCharacter_InvalidId_ShouldReturnNotFound()
        {
            // Act
            var response = await _client.DeleteAsync("/api/characters/9999");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        public async Task SearchCharacters_ShouldReturnResults()
        {
            // Arrange
            var character1 = new Character { CharacterName = "Character Search Test 1" };
            var character2 = new Character { CharacterName = "Character Search Test 2" };
            await _client.PostAsJsonAsync("/api/characters", character1);
            await _client.PostAsJsonAsync("/api/characters", character2);

            // Act
            var response = await _client.GetAsync("/api/characters/search?name=Search");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var characters = JsonSerializer.Deserialize<List<Character>>(responseString);
            Assert.That(characters, Has.Count.GreaterThanOrEqualTo(2));
        }
    }
}
