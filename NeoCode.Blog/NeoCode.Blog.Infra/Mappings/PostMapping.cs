using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Infra.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .ToTable("Posts");

        builder
            .Property(p => p.Id)
            .HasColumnName("id");

        builder
            .Property(p => p.Descricao)
            .IsRequired()
            .HasColumnName("descricao");

        builder
            .Property(p => p.Titulo)
            .IsRequired()
            .HasColumnName("titulo");

        builder
            .Property(p => p.Imagem)
            .IsRequired()
            .HasColumnName("Imagem");
        
        builder
            .Property(p => p.CriandoEm)
            .HasColumnType("timestamp")
            .HasColumnName("data_de_criacao")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .Property(p => p.AtualizadoEm)
            .HasColumnType("timestamp")
            .HasColumnName("data_de_atualizacao")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder
            .Ignore(p => p.CriadoPor);

        builder
            .Ignore(p => p.AtualizadoPor);

        builder
            .HasOne(p => p.Administrador)
            .WithMany(a => a.Posts)
            .HasForeignKey(p => p.AdministradorId);
    }
}