public class TaskService : ITaskService{
    public IEnumerable<Task> GetTasks() => _tasks.Where(t => !t.isDeleted);
    public string AddEditTask(Task task){
        // Add
        if ( task.Id == "0" ){
            task.Id = Guid.NewGuid().ToString();
            _tasks.Add(task);
            return "Task successfully added.";
        }
        // Edit
        else {
            var toEdit = GetTask(task.Id);
            _tasks.Remove(toEdit);
            _tasks.Add(task);
            return "Task successfully modified.";
        }
    }
    public string RemoveTask(Task task){
        var toRemove = GetTask(task.Id);
        task.isDeleted = true;
        _tasks.Remove(toRemove);
        _tasks.Add(task);
        return "Task successfully removed.";
    }

    #region private members
    private static List<Task> _tasks = new(){
        new Task(){
            Id = "1",
            Name = "Vaccuum the bedroom"
        },
        new Task(){
            Id = "2",
            Name = "Wash the dishes"
        },
        new Task(){
            Id = "3",
            Name = "Walk the dog"
        },
        new Task(){
            Id = "4",
            Name = "Fluff the pillows"
        },
        new Task(){
            Id = "5",
            Name = "Make the bed"
        },
    };
    private static Task GetTask(string id) => _tasks.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Task not found.");
    #endregion
}