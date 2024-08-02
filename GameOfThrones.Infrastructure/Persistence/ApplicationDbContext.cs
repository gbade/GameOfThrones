using GameOfThrones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOfThrones.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("character");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.CharacterName)
                    .HasColumnName("charactername")
                    .HasColumnType("text");

                entity.Property(e => e.HouseName)
                    .HasColumnName("housename")
                    .HasColumnType("text");

                entity.Property(e => e.Royal)
                    .HasColumnName("royal")
                    .HasColumnType("boolean");

                entity.Property(e => e.Parents)
                    .HasColumnName("parents")
                    .HasColumnType("text[]");

                entity.Property(e => e.Siblings)
                    .HasColumnName("siblings")
                    .HasColumnType("text[]");

                entity.Property(e => e.KilledBy)
                    .HasColumnName("killedby")
                    .HasColumnType("text[]");

                entity.Property(e => e.Killed)
                    .HasColumnName("killed")
                    .HasColumnType("text[]");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasColumnType("text");

                entity.Property(e => e.CharacterImageThumb)
                    .HasColumnName("characterimagethumb")
                    .HasColumnType("text");

                entity.Property(e => e.CharacterImageFull)
                    .HasColumnName("characterimagefull")
                    .HasColumnType("text");

                entity.Property(e => e.CharacterLink)
                    .HasColumnName("characterlink")
                    .HasColumnType("text");

                entity.Property(e => e.ActorName)
                    .HasColumnName("actorname")
                    .HasColumnType("text");

                entity.Property(e => e.ActorLink)
                    .HasColumnName("actorlink")
                    .HasColumnType("text");
            });
        }
    }
}
