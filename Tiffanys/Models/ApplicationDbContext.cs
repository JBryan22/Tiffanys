using Tiffanys.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tiffanys.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Associate> Associates { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AssociateItem> AssociateItems { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<AssociateItem>()
                   .HasKey(t => new { t.AssociateId, t.ItemId });

            builder.Entity<AssociateItem>()
                   .HasOne(pt => pt.Associate)
                   .WithMany(p => p.AssociateItems)
                   .HasForeignKey(pt => pt.AssociateId);
            
			builder.Entity<AssociateItem>()
				  .HasOne(pt => pt.Item)
				  .WithMany(p => p.AssociateItems)
				  .HasForeignKey(pt => pt.ItemId);
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
				.HasMaxLength(255));
			builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
				.HasMaxLength(255));

			builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
				.HasMaxLength(255));

			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
				.HasMaxLength(255));
			builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));

			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
				.HasMaxLength(255));
			builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
				.HasMaxLength(255));

			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
				.HasMaxLength(255));
			builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
				.HasMaxLength(255));
		}
	}
}
