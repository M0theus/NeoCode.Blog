using NeoCode.Blog.Domain.Contracts;

namespace NeoCode.Blog.Domain.Entities;

public abstract class Entity : IEntity, ITracking
{
    public int Id { get; set; }
    
    public DateTime CriandoEm { get; set; }
    public int? CriadoPor { get; set; }
    
    public DateTime AtualizadoEm { get; set; }
    public int? AtualizadoPor { get; set; }
    
    //Provisório
    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors => _errors;

    public abstract bool Validate();
}