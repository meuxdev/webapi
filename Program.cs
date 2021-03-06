using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("SQLDockerDB"));
// Adding personals the services 
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>(); 
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();
// services.AddControllers().AddNewtonsoftJson();



// builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService(/* Params */)); // Injectando directamente desde la clase

var app = builder.Build();

// Configure the HTTP request pipeline.
// app.Use -> es un middleware.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();


app.UseHttpsRedirection();

app.UseAuthorization();
// After the authorization 


// CUSTOM middleware.
// app.UseWelcomePage(); // Shows a welcome page 
// app.UseTimeMiddleware();
app.UseLoggerMiddleware();
app.UseCategoryValidateMiddleware();


// Before de controllers.



app.MapControllers();


app.Run();
