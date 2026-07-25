namespace WorkersAndTasks.Models;

public class OptimizeRequest
{
    public List<Worker> Workers { get; set; }
    public List<WorkingTask> Tasks { get; set; }
}