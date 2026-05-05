using AdventurersGuild.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace AdventurersGuild.Database;

public class GuildContext : DbContext
{
    public GuildContext(DbContextOptions<GuildContext> options) : base(options)
    {
    }
    public GuildContext() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: настроить сущности (ключи, ограничения, типы столбцов)

        modelBuilder.Entity<Adventurer>(entity =>
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Id)
                .HasColumnType("INTEGER")
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(a => a.Name)
                .HasColumnType("TEXT")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.Rank)
                .HasColumnType("TEXT")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(1);

            entity.Property(a => a.IsActive)
                .HasColumnType("INTEGER")
                .IsRequired()
                .HasDefaultValue(true);

            entity.ToTable("Adventurers");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(q => q.Id);

            entity.Property(q => q.Id)
                .HasColumnType("INTEGER")
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(q => q.Title)
                .HasColumnType("TEXT")
                .HasMaxLength(200);

            entity.Property(q => q.Description)
                .HasColumnType("TEXT")
                .HasMaxLength(2000);

            entity.Property(q => q.Reward)
                .HasColumnType("TEXT")
                .IsRequired()
                .HasPrecision(18, 2);
        });

        // TODO: добавить seed-данные

        modelBuilder.Entity<Adventurer>().HasData(GuildSeed.Adventurers);
        modelBuilder.Entity<Quest>().HasData(GuildSeed.Quests);
    }
    public DbSet<Adventurer> Adventurers { get; set; }
    public DbSet<Quest> Questions { get; set; }
}