using webapi.Models;

namespace webapi.Services;

public class TaskService : ITaskService
{
    private readonly TareasContext context;


    public TaskService(TareasContext _context)
    {
       context = _context;
    }

    public async Task Delete(Guid id)
    {
        var currentTask = context.Tareas.Find(id);

        if(currentTask != null) 
        {
            context.Remove<Tarea>(currentTask);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea task)
    {
        context.Add<Tarea>(task);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea task)
    {
        var currentTask = context.Tareas.Find(id);

        if(currentTask != null) 
        {
            currentTask.CategoriaId = task.CategoriaId;
            currentTask.Descripcion = task.Descripcion;
            currentTask.PrioridadTarea = task.PrioridadTarea;
            currentTask.Titulo = task.Titulo;
            await context.SaveChangesAsync();
        }
    }
}


public interface ITaskService 
{

    IEnumerable<Tarea> Get();

    Task Save(Tarea task);

    Task Delete(Guid id);

    Task Update(Guid id, Tarea task);

}