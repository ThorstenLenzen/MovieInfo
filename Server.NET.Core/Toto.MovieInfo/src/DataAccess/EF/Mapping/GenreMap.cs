using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess.EF.Mapping
{
    internal class GenreMap : DbEntityMap<Genre>
    {
        public override void Map(EntityTypeBuilder<Genre> entity)
        {
            // Primary Key
            entity.HasKey(t => t.Id);

            // Properties
            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            entity.ForSqlServerToTable("Genres");
            entity.Property(t => t.Id).HasColumnName("Id");
            entity.Property(t => t.Name).HasColumnName("Name");
            entity.Property(t => t.Description).HasColumnName("Description");
        }
    }

}
