using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess.EF.Mapping
{
    internal class MovieActorMap : DbEntityMap<MovieActor>
    {
        public override void Map(EntityTypeBuilder<MovieActor> entity)
        {
            // Primary Key
            entity.HasKey(t => new { t.MovieId, t.ActorId });

            // Properties
            // Table & Column Mappings
            entity.ForSqlServerToTable("MovieActors");
            entity.Property(t => t.MovieId).HasColumnName("MovieId");
            entity.Property(t => t.ActorId).HasColumnName("ActorId");
            entity.Property(t => t.IsMainCast).HasColumnName("IsMainCast");

            // Relationships
            entity.HasOne(t => t.Actor)
                .WithMany(t => t.MovieActors)
                .HasForeignKey(d => d.ActorId);
            entity.HasOne(t => t.Movie)
                .WithMany(t => t.MovieActors)
                .HasForeignKey(d => d.MovieId);
        }
    }

}
