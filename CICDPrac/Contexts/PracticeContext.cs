using CICDPrac.Models;
using Microsoft.EntityFrameworkCore;

namespace CICDPrac.Contexts;

public partial class PracticeContext : DbContext
{
    public PracticeContext()
    {
    }

    public PracticeContext(DbContextOptions<PracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=test;user id=yc;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product", tb => tb.HasComment("產品"));

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasComment("產品代號")
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasComment("產品名稱")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(9, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("價錢")
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
