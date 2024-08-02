using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameOfThrones.Domain.Entities
{
    [Table("character")]
    public class Character
    {
        [JsonProperty("id")]
        [Column("id")]
        public int Id { get; set; }
        [JsonProperty("charactername")]
        [Column("charactername")]
        public string CharacterName { get; set; }
        [JsonProperty("housename")]
        [Column("housename")]
        public string HouseName { get; set; }
        [JsonProperty("royal")]
        [Column("royal")]
        public bool? Royal { get; set; }
        [JsonProperty("parents")]
        [Column("parents")]
        public List<string> Parents { get; set; }
        [JsonProperty("siblings")]
        [Column("siblings")]
        public List<string> Siblings { get; set; }
        [JsonProperty("killedby")]
        [Column("killedby")]
        public List<string> KilledBy { get; set; }
        [JsonProperty("killed")]
        [Column("killed")]
        public List<string> Killed { get; set; }
        [JsonProperty("nickname")]
        [Column("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("characterimagethumb")]
        [Column("characterimagethumb")]
        public string CharacterImageThumb { get; set; }
        [JsonProperty("characterimagefull")]
        [Column("characterimagefull")]
        public string CharacterImageFull { get; set; }
        [JsonProperty("characterlink")]
        [Column("characterlink")]
        public string CharacterLink { get; set; }
        [JsonProperty("actorname")]
        [Column("actorname")]
        public string ActorName { get; set; }
        [JsonProperty("actorlink")]
        [Column("actorlink")]
        public string ActorLink { get; set; }
    }
}
