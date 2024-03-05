using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Speedtest.Models;

public partial class EsemkaHeroContext : DbContext
{
    public EsemkaHeroContext()
    {
    }

    public EsemkaHeroContext(DbContextOptions<EsemkaHeroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clan> Clans { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<FightHistory> FightHistories { get; set; }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<HeroSkill> HeroSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=EsemkaHero;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clan>(entity =>
        {
            entity.ToTable("Clan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.ToTable("Element");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Element1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Element");
        });

        modelBuilder.Entity<FightHistory>(entity =>
        {
            entity.ToTable("FightHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FightDate).HasColumnType("datetime");
            entity.Property(e => e.Hero1Id).HasColumnName("Hero1ID");
            entity.Property(e => e.Hero2Id).HasColumnName("Hero2ID");

            entity.HasOne(d => d.Hero1).WithMany(p => p.FightHistoryHero1s)
                .HasForeignKey(d => d.Hero1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FightHistory_Hero1");

            entity.HasOne(d => d.Hero2).WithMany(p => p.FightHistoryHero2s)
                .HasForeignKey(d => d.Hero2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FightHistory_Hero2");
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.ToTable("Hero");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClanId).HasColumnName("ClanID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Clan).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.ClanId)
                .HasConstraintName("FK_Hero_Clan");
        });

        modelBuilder.Entity<HeroSkill>(entity =>
        {
            entity.ToTable("HeroSkill");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HeroId).HasColumnName("HeroID");
            entity.Property(e => e.SkillId).HasColumnName("SkillID");

            entity.HasOne(d => d.Hero).WithMany(p => p.HeroSkills)
                .HasForeignKey(d => d.HeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HeroSkill_Hero");

            entity.HasOne(d => d.Skill).WithMany(p => p.HeroSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HeroSkill_Skill");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ElementId).HasColumnName("ElementID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Element).WithMany(p => p.Skills)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_Skill_Element");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
