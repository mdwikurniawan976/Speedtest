using Speedtest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Speedtest.Dto
{
    public class ClanDTO : Clan
    {
        [JsonIgnore]
        public new int Id { get => base.Id; set=> base.Id = value; }
        [Required]
        [MaxLength(255)]    
        public new string Name { get => base.Name; set => base.Name = value; }

        public new string Description { get => base.Description; set => base.Description = value; }

        [JsonIgnore]
        public override ICollection<Hero> Heroes { get => base.Heroes; set => base.Heroes = value; }
    }
}
