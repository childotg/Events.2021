using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataPrep.Database
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KeyValue> KeyValues { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviesFullJson> MoviesFullJsons { get; set; }
        public virtual DbSet<MoviesHybrid> MoviesHybrids { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<VMovie> VMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<KeyValue>(entity =>
            {
                entity.ToTable("KeyValue", "playground");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies", "relational");

                entity.Property(e => e.MovieId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.PlotSummary).HasColumnName("plot_summary");

                entity.Property(e => e.PlotSynopsis).HasColumnName("plot_synopsis");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");
            });

            modelBuilder.Entity<MoviesFullJson>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__MoviesFu__83CDF7494916CB2F");

                entity.ToTable("MoviesFullJson", "json");

                entity.Property(e => e.MovieId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie_id");

                entity.Property(e => e.Movie).HasColumnName("movie");

                entity.Property(e => e.Reviews).HasColumnName("reviews");
            });

            modelBuilder.Entity<MoviesHybrid>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("PK__MoviesHy__83CDF74911894C46");

                entity.ToTable("MoviesHybrid", "json");

                entity.Property(e => e.MovieId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.PlotSummary).HasColumnName("plot_summary");

                entity.Property(e => e.PlotSynopsis).HasColumnName("plot_synopsis");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Reviews).HasColumnName("reviews");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews", "relational");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.IsSpoiler).HasColumnName("is_spoiler");

                entity.Property(e => e.MovieId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie_id");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("date")
                    .HasColumnName("review_date");

                entity.Property(e => e.ReviewSummary).HasColumnName("review_summary");

                entity.Property(e => e.ReviewText).HasColumnName("review_text");

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reviews__movie_i__5EBF139D");
            });

            modelBuilder.Entity<VMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMovies", "json");

                entity.Property(e => e.DurationRaw).HasColumnName("durationRaw");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.MovieId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("movie_id");

                entity.Property(e => e.PlotSummary)
                    .HasMaxLength(4000)
                    .HasColumnName("plot_summary");

                entity.Property(e => e.PlotSynopsis)
                    .HasMaxLength(4000)
                    .HasColumnName("plot_synopsis");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
