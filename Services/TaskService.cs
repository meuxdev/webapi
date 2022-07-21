using webapi.Models;
using Microsoft.EntityFrameworkCore;


namespace webapi.Services;

public class TaskService : ITaskService
{
    private readonly TareasContext context;


    public TaskService(TareasContext _context)
    {
        context = _context;
    }

    public async Task<Tarea?> Delete(Guid id)
    {
        var currentTask = context.Tareas.Find(id);

        if (currentTask != null)
        {
            context.Remove<Tarea>(currentTask);
            await context.SaveChangesAsync();
        }
        return currentTask;
    }

    public IEnumerable<Tarea> GetAll()
    {
        return context.Tareas.Include(task => task.Categoria);
    }

    public async Task<Tarea?> GetById(Guid id)
    {
        Tarea? t = await context.Tareas.FindAsync(id);
        return t;
    }

    public async Task<Tarea?> Save(PostTaskRequestDto dto)
    {
        Categoria? category = await context.Categorias.FindAsync(dto.CategoriaId);

        if (category == null)
        {
            return null;
        }

        Tarea newTask = TareaFactory.ParsePostDto(dto);
        context.Add<Tarea>(newTask);
        await context.SaveChangesAsync();
        return newTask;
    }

    public async Task<Tarea?> Update(Guid id, PutTaskRequestDto dto)
    {
        var currentTask = await context.Tareas.FindAsync(id);



        if (currentTask != null)
        {
            if (currentTask.CategoriaId != dto.CategoriaId)
            {
                // category update,
                // validate that the category exists
                var category = await context.Categorias.FindAsync(dto.CategoriaId);
                if (category != null)
                {
                    currentTask.CategoriaId = category.CategoriaId;
                }
                else
                {
                    return null;
                }

            }
            currentTask.Descripcion = dto.Descripcion;
            currentTask.PrioridadTarea = dto.PrioridadTarea;
            currentTask.Titulo = dto.Titulo;
            await context.SaveChangesAsync();
        }
        return currentTask;
    }

}


public interface ITaskService
{

    IEnumerable<Tarea> GetAll(); // returns all the tasks in the db context

    Task<Tarea?> GetById(Guid id);

    Task<Tarea?> Save(PostTaskRequestDto dto); // Saves a task in the db context

    Task<Tarea?> Delete(Guid id); // Deletes one task in the db context

    Task<Tarea?> Update(Guid id, PutTaskRequestDto task); // Updates the task in the db context

}
