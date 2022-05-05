using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI Container
builder.Services.AddSingleton<ITaskService, TaskService>();

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

app.MapGet("/tasks", ([FromServices]ITaskService taskService) => {
    try{
        return new Response(jsonData:taskService.GetTasks());
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.MapPost("/tasks/AddEdit", ([FromServices]ITaskService taskService, [FromBody]Task task) => {
    try{
        return new Response(message:taskService.AddEditTask(task));
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.MapPost("/tasks/Remove", ([FromServices]ITaskService taskService, [FromBody]Task task) => {
    try{
        return new Response(message:taskService.RemoveTask(task));
    }
    catch (Exception e){
        return new Response(isSuccess:false, message:$"Service call failed. {e}");
    }
});

app.Run();