using Speedtest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Speedtest.Dto
{
    public class ElementDTO : Element
    {
        [JsonIgnore]
        public new int Id { get => base.Id; set=> base.Id = value; }

        [Required]
        public new string  Element1 { get => base.Element1; set => base.Element1 = value; } 

        [JsonIgnore]
        public override ICollection<Skill> Skills { get => base.Skills; set => base.Skills = value; }
    }
}
