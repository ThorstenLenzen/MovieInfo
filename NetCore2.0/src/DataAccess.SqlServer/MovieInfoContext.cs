using Microsoft.EntityFrameworkCore;
using PersistenceModel.SqlServer;

namespace Toto.MovieInfo.DataAccess.SqlServer
{
    public partial class MovieInfoContext : DbContext
    {
        public MovieInfoContext()
        {
        }

        public MovieInfoContext(DbContextOptions<MovieInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MovieInfoData; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
