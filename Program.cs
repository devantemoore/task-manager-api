using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return new Response();
});

app.MapGet("/tasks", () => {
    try{
        return new Response(jsonData:TaskService.GetTasks());
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.MapPost("/tasks/AddEdit", (Task task) => {
    try{
        return new Response(message:TaskService.AddEditTask(task));
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.MapPost("/tasks/Remove", (Task task) => {
    try{
        return new Response(message:TaskService.RemoveTask(task));
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.Run();