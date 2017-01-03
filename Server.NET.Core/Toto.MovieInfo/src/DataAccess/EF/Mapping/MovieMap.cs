using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toto.MovieInfo.DataAccess.EF.Mapping;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess.EF.Mapping
{
    internal class MovieMap : DbEntityMap<Movie>
    {
        public override void Map(EntityTypeBuilder<Movie> entity)
        {
            // Primary Key
            entity.HasKey(t => t.Id);

            // Properties
            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(t => t.Description)
                .HasMaxLength(500);

            entity.Property(t => t.ReleaseDate)
                .HasMaxLength(4);

            // Table & Column Mappings
            entity.ForSqlServerToTable("Movies");
            entity.Property(t => t.Id).HasColumnName("Id");
            entity.Property(t => t.GenreId).HasColumnName("GenreId");
            entity.Property(t => t.Name).HasColumnName("Name");
            entity.Property(t => t.Description).HasColumnName("Description");
            entity.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");

            // Relationships
            entity.HasOne(t => t.Genre)
                .WithMany(t => t.Movies)
                .HasForeignKey(d => d.GenreId);
        }
    }

}
