using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senai.Core.Models;

namespace Senai.Api.Data.Mappins
{
    public class CarsMapping: IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.ToTable("Carros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Marca)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(x => x.Modelo)
                .IsRequired(true)
                .HasMaxLength(80);

            builder.Property(x => x.Cor)
                .IsRequired(false)
                .HasMaxLength(20);

            builder.Property(x => x.Placa)
                .IsRequired(false)
                .HasMaxLength(7);

            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasMaxLength(160);
                
        }
    }
}
