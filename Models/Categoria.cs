using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Categoria : CategoryBase
{
    public Guid CategoriaId { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}


public abstract class CategoryBase
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Peso { get; set; }
}

public class CategoryPostDto : CategoryBase
{
}

