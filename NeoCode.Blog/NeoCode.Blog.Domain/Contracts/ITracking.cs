namespace NeoCode.Blog.Domain.Contracts;

public interface ITracking
{
    public DateTime CriandoEm { get; set; }
    public int? CriadoPor { get; set; }

    public DateTime AtualizadoEm { get; set; }
    public int? AtualizadoPor { get; set; }
}