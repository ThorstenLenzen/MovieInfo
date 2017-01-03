using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Toto.MovieInfo.PersistenceModel;

namespace Toto.MovieInfo.DataAccess.EF.Mapping
{
    internal class ActorMap : DbEntityMap<Actor>
    {
        public override void Map(EntityTypeBuilder<Actor> entity)
        {
            // Primary Key
            entity.HasKey(t => t.Id);

            // Properties
            entity.Property(t => t.FirstName)
                .HasMaxLength(50);

            entity.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            entity.ForSqlServerToTable("Actors");
            entity.Property(t => t.Id).HasColumnName("Id");
            entity.Property(t => t.FirstName).HasColumnName("FirstName");
            entity.Property(t => t.LastName).HasColumnName("LastName");
        }
    }

}
