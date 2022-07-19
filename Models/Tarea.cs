using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Tarea
{
    public Guid TareaId { get; init; }
    public Guid CategoriaId { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreacion { get; init; }
    public virtual Categoria Categoria { get; set; }
    public string Resumen { get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}