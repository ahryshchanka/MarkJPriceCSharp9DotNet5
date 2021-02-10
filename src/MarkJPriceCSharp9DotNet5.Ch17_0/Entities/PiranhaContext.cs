using Microsoft.EntityFrameworkCore;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaContext : DbContext
    {
        public PiranhaContext()
        {
        }

        public PiranhaContext(DbContextOptions<PiranhaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PiranhaAliases> PiranhaAliases { get; set; }
        public virtual DbSet<PiranhaBlockFields> PiranhaBlockFields { get; set; }
        public virtual DbSet<PiranhaBlocks> PiranhaBlocks { get; set; }
        public virtual DbSet<PiranhaCategories> PiranhaCategories { get; set; }
        public virtual DbSet<PiranhaMedia> PiranhaMedia { get; set; }
        public virtual DbSet<PiranhaMediaFolders> PiranhaMediaFolders { get; set; }
        public virtual DbSet<PiranhaMediaVersions> PiranhaMediaVersions { get; set; }
        public virtual DbSet<PiranhaPageBlocks> PiranhaPageBlocks { get; set; }
        public virtual DbSet<PiranhaPageComments> PiranhaPageComments { get; set; }
        public virtual DbSet<PiranhaPageFields> PiranhaPageFields { get; set; }
        public virtual DbSet<PiranhaPagePermissions> PiranhaPagePermissions { get; set; }
        public virtual DbSet<PiranhaPageRevisions> PiranhaPageRevisions { get; set; }
        public virtual DbSet<PiranhaPageTypes> PiranhaPageTypes { get; set; }
        public virtual DbSet<PiranhaPages> PiranhaPages { get; set; }
        public virtual DbSet<PiranhaParams> PiranhaParams { get; set; }
        public virtual DbSet<PiranhaPostBlocks> PiranhaPostBlocks { get; set; }
        public virtual DbSet<PiranhaPostComments> PiranhaPostComments { get; set; }
        public virtual DbSet<PiranhaPostFields> PiranhaPostFields { get; set; }
        public virtual DbSet<PiranhaPostPermissions> PiranhaPostPermissions { get; set; }
        public virtual DbSet<PiranhaPostRevisions> PiranhaPostRevisions { get; set; }
        public virtual DbSet<PiranhaPostTags> PiranhaPostTags { get; set; }
        public virtual DbSet<PiranhaPostTypes> PiranhaPostTypes { get; set; }
        public virtual DbSet<PiranhaPosts> PiranhaPosts { get; set; }
        public virtual DbSet<PiranhaRoleClaims> PiranhaRoleClaims { get; set; }
        public virtual DbSet<PiranhaRoles> PiranhaRoles { get; set; }
        public virtual DbSet<PiranhaSiteFields> PiranhaSiteFields { get; set; }
        public virtual DbSet<PiranhaSiteTypes> PiranhaSiteTypes { get; set; }
        public virtual DbSet<PiranhaSites> PiranhaSites { get; set; }
        public virtual DbSet<PiranhaTags> PiranhaTags { get; set; }
        public virtual DbSet<PiranhaUserClaims> PiranhaUserClaims { get; set; }
        public virtual DbSet<PiranhaUserLogins> PiranhaUserLogins { get; set; }
        public virtual DbSet<PiranhaUserRoles> PiranhaUserRoles { get; set; }
        public virtual DbSet<PiranhaUserTokens> PiranhaUserTokens { get; set; }
        public virtual DbSet<PiranhaUsers> PiranhaUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=piranha.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PiranhaAliases>(entity =>
            {
                entity.ToTable("Piranha_Aliases");

                entity.HasIndex(e => new { e.SiteId, e.AliasUrl })
                    .IsUnique();

                entity.Property(e => e.AliasUrl).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.Property(e => e.RedirectUrl).IsRequired();

                entity.Property(e => e.SiteId).IsRequired();

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaAliases)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaBlockFields>(entity =>
            {
                entity.ToTable("Piranha_BlockFields");

                entity.HasIndex(e => new { e.BlockId, e.FieldId, e.SortOrder })
                    .IsUnique();

                entity.Property(e => e.BlockId).IsRequired();

                entity.Property(e => e.Clrtype)
                    .IsRequired()
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).IsRequired();

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaBlockFields)
                    .HasForeignKey(d => d.BlockId);
            });

            modelBuilder.Entity<PiranhaBlocks>(entity =>
            {
                entity.ToTable("Piranha_Blocks");

                entity.Property(e => e.Clrtype)
                    .IsRequired()
                    .HasColumnName("CLRType");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaCategories>(entity =>
            {
                entity.ToTable("Piranha_Categories");

                entity.HasIndex(e => new { e.BlogId, e.Slug })
                    .IsUnique();

                entity.Property(e => e.BlogId).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaCategories)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<PiranhaMedia>(entity =>
            {
                entity.ToTable("Piranha_Media");

                entity.HasIndex(e => e.FolderId);

                entity.Property(e => e.ContentType).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Filename).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.PiranhaMedia)
                    .HasForeignKey(d => d.FolderId);
            });

            modelBuilder.Entity<PiranhaMediaFolders>(entity =>
            {
                entity.ToTable("Piranha_MediaFolders");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PiranhaMediaVersions>(entity =>
            {
                entity.ToTable("Piranha_MediaVersions");

                entity.HasIndex(e => new { e.MediaId, e.Width, e.Height })
                    .IsUnique();

                entity.Property(e => e.MediaId).IsRequired();

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.PiranhaMediaVersions)
                    .HasForeignKey(d => d.MediaId);
            });

            modelBuilder.Entity<PiranhaPageBlocks>(entity =>
            {
                entity.ToTable("Piranha_PageBlocks");

                entity.HasIndex(e => e.BlockId);

                entity.HasIndex(e => new { e.PageId, e.SortOrder })
                    .IsUnique();

                entity.Property(e => e.BlockId).IsRequired();

                entity.Property(e => e.PageId).IsRequired();

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaPageBlocks)
                    .HasForeignKey(d => d.BlockId);

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageBlocks)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageComments>(entity =>
            {
                entity.ToTable("Piranha_PageComments");

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PageId).IsRequired();

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageComments)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageFields>(entity =>
            {
                entity.ToTable("Piranha_PageFields");

                entity.HasIndex(e => new { e.PageId, e.RegionId, e.FieldId, e.SortOrder });

                entity.Property(e => e.Clrtype)
                    .IsRequired()
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).IsRequired();

                entity.Property(e => e.PageId).IsRequired();

                entity.Property(e => e.RegionId).IsRequired();

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageFields)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPagePermissions>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.Permission });

                entity.ToTable("Piranha_PagePermissions");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPagePermissions)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageRevisions>(entity =>
            {
                entity.ToTable("Piranha_PageRevisions");

                entity.HasIndex(e => e.PageId);

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.PageId).IsRequired();

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PiranhaPageRevisions)
                    .HasForeignKey(d => d.PageId);
            });

            modelBuilder.Entity<PiranhaPageTypes>(entity =>
            {
                entity.ToTable("Piranha_PageTypes");

                entity.Property(e => e.Clrtype).HasColumnName("CLRType");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaPages>(entity =>
            {
                entity.ToTable("Piranha_Pages");

                entity.HasIndex(e => e.PageTypeId);

                entity.HasIndex(e => e.ParentId);

                entity.HasIndex(e => new { e.SiteId, e.Slug })
                    .IsUnique();

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasDefaultValueSql("'Page'");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.Property(e => e.OgImageId)
                    .IsRequired()
                    .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                entity.Property(e => e.PageTypeId).IsRequired();

                entity.Property(e => e.SiteId).IsRequired();

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.PageType)
                    .WithMany(p => p.PiranhaPages)
                    .HasForeignKey(d => d.PageTypeId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaPages)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaParams>(entity =>
            {
                entity.ToTable("Piranha_Params");

                entity.HasIndex(e => e.Key)
                    .IsUnique();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Key).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaPostBlocks>(entity =>
            {
                entity.ToTable("Piranha_PostBlocks");

                entity.HasIndex(e => e.BlockId);

                entity.HasIndex(e => new { e.PostId, e.SortOrder })
                    .IsUnique();

                entity.Property(e => e.BlockId).IsRequired();

                entity.Property(e => e.PostId).IsRequired();

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.PiranhaPostBlocks)
                    .HasForeignKey(d => d.BlockId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostBlocks)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostComments>(entity =>
            {
                entity.ToTable("Piranha_PostComments");

                entity.HasIndex(e => e.PostId);

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PostId).IsRequired();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostComments)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostFields>(entity =>
            {
                entity.ToTable("Piranha_PostFields");

                entity.HasIndex(e => new { e.PostId, e.RegionId, e.FieldId, e.SortOrder });

                entity.Property(e => e.Clrtype)
                    .IsRequired()
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).IsRequired();

                entity.Property(e => e.PostId).IsRequired();

                entity.Property(e => e.RegionId).IsRequired();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostFields)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostPermissions>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.Permission });

                entity.ToTable("Piranha_PostPermissions");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostPermissions)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostRevisions>(entity =>
            {
                entity.ToTable("Piranha_PostRevisions");

                entity.HasIndex(e => e.PostId);

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.PostId).IsRequired();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostRevisions)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<PiranhaPostTags>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId });

                entity.ToTable("Piranha_PostTags");

                entity.HasIndex(e => e.TagId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PiranhaPostTags)
                    .HasForeignKey(d => d.PostId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PiranhaPostTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PiranhaPostTypes>(entity =>
            {
                entity.ToTable("Piranha_PostTypes");

                entity.Property(e => e.Clrtype).HasColumnName("CLRType");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaPosts>(entity =>
            {
                entity.ToTable("Piranha_Posts");

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.PostTypeId);

                entity.HasIndex(e => new { e.BlogId, e.Slug })
                    .IsUnique();

                entity.Property(e => e.BlogId).IsRequired();

                entity.Property(e => e.CategoryId).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.Property(e => e.OgImageId)
                    .IsRequired()
                    .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                entity.Property(e => e.PostTypeId).IsRequired();

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.BlogId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PostType)
                    .WithMany(p => p.PiranhaPosts)
                    .HasForeignKey(d => d.PostTypeId);
            });

            modelBuilder.Entity<PiranhaRoleClaims>(entity =>
            {
                entity.ToTable("Piranha_RoleClaims");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PiranhaRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<PiranhaRoles>(entity =>
            {
                entity.ToTable("Piranha_Roles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();
            });

            modelBuilder.Entity<PiranhaSiteFields>(entity =>
            {
                entity.ToTable("Piranha_SiteFields");

                entity.HasIndex(e => new { e.SiteId, e.RegionId, e.FieldId, e.SortOrder });

                entity.Property(e => e.Clrtype)
                    .IsRequired()
                    .HasColumnName("CLRType");

                entity.Property(e => e.FieldId).IsRequired();

                entity.Property(e => e.RegionId).IsRequired();

                entity.Property(e => e.SiteId).IsRequired();

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.PiranhaSiteFields)
                    .HasForeignKey(d => d.SiteId);
            });

            modelBuilder.Entity<PiranhaSiteTypes>(entity =>
            {
                entity.ToTable("Piranha_SiteTypes");

                entity.Property(e => e.Clrtype).HasColumnName("CLRType");

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaSites>(entity =>
            {
                entity.ToTable("Piranha_Sites");

                entity.HasIndex(e => e.InternalId)
                    .IsUnique();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.InternalId).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();
            });

            modelBuilder.Entity<PiranhaTags>(entity =>
            {
                entity.ToTable("Piranha_Tags");

                entity.HasIndex(e => new { e.BlogId, e.Slug })
                    .IsUnique();

                entity.Property(e => e.BlogId).IsRequired();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.LastModified).IsRequired();

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.PiranhaTags)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<PiranhaUserClaims>(entity =>
            {
                entity.ToTable("Piranha_UserClaims");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("Piranha_UserLogins");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("Piranha_UserRoles");

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PiranhaUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("Piranha_UserTokens");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PiranhaUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PiranhaUsers>(entity =>
            {
                entity.ToTable("Piranha_Users");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}