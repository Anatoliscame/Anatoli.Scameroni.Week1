using GestioneSpese.Entita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneSpese.Configuration
{
    internal class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Categoria).IsRequired().HasMaxLength(100);
        }
    }
}