using webapi.Models;
namespace webapi.Services;

public class CategoryService : ICategoryService
{
    TareasContext context;
    
    public CategoryService(TareasContext _context) 
    {
        context = _context; // Context db
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public void Save(Categoria categoria)
    {
        context.Add(categoria);
        context.SaveChanges();
    }

    public async Task SaveAsync(Categoria categoria) 
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, Categoria categoria)
    {
        Categoria currentCategory = context.Categorias.Find(id);

        if(currentCategory != null) 
        {
            currentCategory.Nombre = categoria.Nombre;
            currentCategory.Descripcion = categoria.Descripcion;
            currentCategory.Peso = categoria.Peso;
            await context.SaveChangesAsync();
        }

    }

    public async Task DeleteAsync(Guid id)
    {
        Categoria currentCategory = context.Categorias.Find(id);

        if(currentCategory != null) 
        {
            context.Remove(currentCategory);
            await context.SaveChangesAsync();
        }

    }
}


public interface ICategoryService
{
    IEnumerable<Categoria> Get();

    void Save(Categoria category);

    Task SaveAsync(Categoria category);

    Task UpdateAsync(Guid id, Categoria category);

    Task DeleteAsync(Guid id);

}