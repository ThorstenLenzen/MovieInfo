using Microsoft.EntityFrameworkCore;
using Toto.MovieInfo.DataAccess.EF.Mapping;

namespace Toto.MovieInfo.DataAccess.EF.Helper
{
    internal static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, DbEntityMap<TEntity> entityMap) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityMap.Map);
        }
    }

}
