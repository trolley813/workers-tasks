using WorkersAndTasks.Models;

namespace WorkersAndTasks.Services;

public interface ISchedulerService
{
    public Schedule GetSchedule(DateTime start, List<Worker> workers, List<WorkingTask> tasks);
}