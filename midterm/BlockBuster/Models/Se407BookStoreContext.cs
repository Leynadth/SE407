using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Bookstore.Models
{
	public partial class Se407BookstoreContext : DbContext
	{
		public Se407BookstoreContext()
		{
		}

		public Se407BookstoreContext(DbContextOptions<Se407BookstoreContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Book> Books { get; set; } = null!;
		public virtual DbSet<Author> Authors { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=sql.neit.edu,4500;User Id=SE407_BookStore;Password=B00k$t0r3;Database=SE407_BookStore;TrustServerCertificate = true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>(entity =>
			{
				entity.HasKey(e => e.BookId);

				entity.Property(e => e.Title).IsRequired();
				entity.Property(e => e.ReleaseYear).IsRequired();

				entity.HasOne(d => d.Author)
					.WithMany(p => p.Books)
					.HasForeignKey(d => d.AuthorId)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Author>(entity =>
			{
				entity.HasKey(e => e.AuthorId);

				entity.Property(e => e.FirstName).IsRequired();
				entity.Property(e => e.LastName).IsRequired();
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
