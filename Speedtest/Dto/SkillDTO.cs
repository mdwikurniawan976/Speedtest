using Speedtest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Speedtest.Dto
{
    public class SkillDTO : Skill
    {
        [JsonIgnore]
       
        public new int Id { get=> base.Id; set=> base.Id = value; }
        [Required]
        [MaxLength(255)]
        public new string Name { get => base.Name; set => base.Name = value; }

        [Required]
        [MaxLength(255)]
        public new string DifficultyLevel { get => base.DifficultyLevel; set => base.DifficultyLevel = value; }

        [JsonIgnore]
        public override Element? Element { get => base.Element; set => base.Element = value; }
        [JsonIgnore]
        public override ICollection<HeroSkill> HeroSkills { get => base.HeroSkills; set => base.HeroSkills = value; }

       

        public string? ElementName { get => base.Element?.Element1; set => base.Element.Element1 = value; }
    }
}
