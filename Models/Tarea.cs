using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public abstract class TaskInformation
{

    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public Guid CategoriaId { get; set; }
}

public class Tarea : TaskInformation
{
    public Guid TareaId { get; init; }
    public DateTime FechaCreacion { get; init; }
    public virtual Categoria? Categoria { get; set; }
    public string? Resumen { get; set; }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}





public class PostTaskRequestDto : TaskInformation
{

}


public class PutTaskRequestDto : TaskInformation
{
    public Guid TaskId { get; set; }
}


public static class TareaFactory
{
    public static Tarea ParsePostDto(PostTaskRequestDto dto)
    {
        return new Tarea()
        {
            TareaId = Guid.NewGuid(),
            CategoriaId = dto.CategoriaId,
            Descripcion = dto.Descripcion,
            FechaCreacion = DateTime.Now,
            PrioridadTarea = dto.PrioridadTarea,
            Titulo = dto.Titulo
        };
    }
}