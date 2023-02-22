using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HotMusic.Models
{
    public partial class HotMusicContext : DbContext
    {
        public HotMusicContext()
        {
        }

        public HotMusicContext(DbContextOptions<HotMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumMusic> AlbumMusics { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cbvip> Cbvips { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ListFavorite> ListFavorites { get; set; }
        public virtual DbSet<ListFavoriteDetail> ListFavoriteDetails { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<MusicMp3> MusicMp3s { get; set; }
        public virtual DbSet<Singer> Singers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;user Id=sa;password=1;database=HotMusic;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.IdVipNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdVip)
                    .HasConstraintName("FK_Account_CBVIP");
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.Imange).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Album_Category");
            });

            modelBuilder.Entity<AlbumMusic>(entity =>
            {
                entity.ToTable("AlbumMusic");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumMusics)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_AlbumMusic_Album");

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.AlbumMusics)
                    .HasForeignKey(d => d.MusicId)
                    .HasConstraintName("FK_AlbumMusic_Music");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorName).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Cbvip>(entity =>
            {
                entity.ToTable("CBVIP");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Comment_Account");

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MusicId)
                    .HasConstraintName("FK_Comment_Music");
            });

            modelBuilder.Entity<ListFavorite>(entity =>
            {
                entity.ToTable("ListFavorite");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ListFavorites)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_ListFavorite_Account");
            });

            modelBuilder.Entity<ListFavoriteDetail>(entity =>
            {
                entity.Property(e => e.MusicName).HasMaxLength(50);

                entity.HasOne(d => d.ListFavorite)
                    .WithMany(p => p.ListFavoriteDetails)
                    .HasForeignKey(d => d.ListFavoriteId)
                    .HasConstraintName("FK_ListFavoriteDetails_ListFavorite");

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.ListFavoriteDetails)
                    .HasForeignKey(d => d.MusicId)
                    .HasConstraintName("FK_ListFavoriteDetails_Music");
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("Music");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.IsVip).HasColumnName("isVIP");

                entity.Property(e => e.MusiceName).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Musics)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Music_Author");
            });

            modelBuilder.Entity<MusicMp3>(entity =>
            {
                entity.ToTable("MusicMp3");

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.MusicMp3s)
                    .HasForeignKey(d => d.MusicId)
                    .HasConstraintName("FK_MusicMp3_Music");

                entity.HasOne(d => d.Singer)
                    .WithMany(p => p.MusicMp3s)
                    .HasForeignKey(d => d.SingerId)
                    .HasConstraintName("FK_MusicMp3_Singer");
            });

            modelBuilder.Entity<Singer>(entity =>
            {
                entity.ToTable("Singer");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.SingerName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
