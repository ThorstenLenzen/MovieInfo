using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Toto.MovieInfo.DataAccess.EF.Mapping
{
    internal abstract class DbEntityMap<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> entity);
    }
}
