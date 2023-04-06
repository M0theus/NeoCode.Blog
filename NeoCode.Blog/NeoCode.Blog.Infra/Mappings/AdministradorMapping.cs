using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Infra.Mappings;

public class AdministradorMapping : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder
            .ToTable("Administradores");

        builder
            .Property(a => a.Id)
            .HasColumnName("id");

        builder
            .Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("email");

        builder
            .Property(a => a.Senha)
            .IsRequired()
            .HasColumnName("senha");
        
        builder
            .Property(a => a.CriandoEm)
            .HasColumnType("timestamp")
            .HasColumnName("data_de_criacao")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .Property(a => a.AtualizadoEm)
            .HasColumnType("timestamp")
            .HasColumnName("data_de_atualizacao")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .Ignore(a => a.CriadoPor);

        builder
            .Ignore(a => a.AtualizadoPor);
    }
}