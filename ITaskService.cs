public interface ITaskService{
    public IEnumerable<Task> GetTasks();
    public  string AddEditTask(Task task);
    public string RemoveTask(Task task);
}