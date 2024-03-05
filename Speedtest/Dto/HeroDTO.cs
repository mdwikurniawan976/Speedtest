
using Speedtest.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Speedtest
{
    public class HeroDTO : Hero
    {
        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }
        [Required]
        [MaxLength(250)]
        public new string Name { get => base.Name; set => base.Name = value; }

        public new string? Description { get => base.Description; set => base.Description = value; }

        public new DateTime BirthDate { get => base.BirthDate.ToDateTime(TimeOnly.MinValue); set => base.BirthDate = DateOnly.FromDateTime(value); }

        public string date { get => BirthDate.ToString("dd MMMM yyyy"); }
        [Required]

        public string? ClanName { get => base.Clan?.Name; }

        [JsonIgnore]
        public new int? ClanId { get => base.ClanId; set => base.ClanId = value; }

        [JsonIgnore]
        public override Clan? Clan { get => base.Clan; set => base.Clan = value; }
        [JsonIgnore]
        public override ICollection<FightHistory> FightHistoryHero1s { get => base.FightHistoryHero1s; set => base.FightHistoryHero1s = value; }
        [JsonIgnore]
        public override ICollection<FightHistory> FightHistoryHero2s { get => base.FightHistoryHero2s; set => base.FightHistoryHero2s = value; }
        [JsonIgnore]
        public override ICollection<HeroSkill> HeroSkills { get => base.HeroSkills; set => base.HeroSkills = value; }
    }
}