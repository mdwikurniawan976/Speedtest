using Speedtest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Speedtest.Dto
{
    public class HeroskillDTO : HeroSkill
    {
        [JsonIgnore]
        public new int Id { get=> base.Id; set => base.Id = value; }

      

        [Required]
      
        public new int HeroId { get => base.HeroId; set => base.HeroId = value; }


        [Required]
        public new int SkillId { get => base.SkillId; set => base.SkillId = value; }

        [Required]
        public new double Power { get => base.Power; set => base.Power = value; }


        [JsonIgnore]
        public override Hero Hero { get => base.Hero; set => base.Hero = value; }
        [JsonIgnore]
        public override Skill Skill { get => base.Skill; set => base.Skill = value; }

        public string HeroName { get => base.Hero.Name; set=> base.Hero.Name = value; }

        public string SkillName { get => base.Skill.Name; set=> base.Skill.Name = value;}
    }
}
