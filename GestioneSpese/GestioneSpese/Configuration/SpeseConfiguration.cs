using GestioneSpese.Entita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneSpese.Configuration
{
    internal class SpeseConfiguration : IEntityTypeConfiguration<Spese>
    {
        public void Configure(EntityTypeBuilder<Spese> builder)
        {
           builder.ToTable("Spese");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Data).IsRequired();
            builder.Property(d => d.Descrizione).IsRequired().HasMaxLength(500);
            builder.Property(d => d.Utente).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Importo).IsRequired();  
            builder.Property(d => d.Approvato).IsRequired();
    
      
            builder.HasOne(r => r.Categoria).WithMany(d => d.Spese).HasForeignKey(r => r.CategoriaId).HasConstraintName("SpeseCategorieOneMany");
        }
    }
}
