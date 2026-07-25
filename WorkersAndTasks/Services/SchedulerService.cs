using WorkersAndTasks.Models;

namespace WorkersAndTasks.Services;

public class SchedulerService : ISchedulerService
{
    public Schedule GetSchedule(DateTime start, List<Worker> workers, List<WorkingTask> tasks)
    {
        // сортируем задачи, сначала по приоритету, потом по сложности (сначала самые сложные) 
        tasks.Sort((t1, t2) =>
        {
            var priorityCompare = -t1.Priority.CompareTo(t2.Priority);
            if (priorityCompare == 0) return -t1.Duration.CompareTo(t2.Duration);
            return priorityCompare;
        });
        var schedule = new Schedule();
        // "текущее время" для каждого исполнителя
        var workerTimes = workers.Select(w => (w, w.GetAvailableStartTime(start))).ToDictionary();
        foreach (var task in tasks)
        {
            // для каждой задачи находим исполнителя, который сделает ее быстрее всех
            var (worker, finishTime) = workers
                .Select(w => (w, w.GetFinishTime(workerTimes[w], task)))
                .OrderBy((x) => x.Item2)
                .First();
            schedule.Items.Add(new ScheduleItem
            {
                WorkerId = worker.Id,
                TaskId =  task.Id,
                Start = workerTimes[worker],
                Finish = finishTime
            });
            workerTimes[worker] = finishTime;
        }
        schedule.FinishTime = workerTimes.Values.Max();
        return schedule;
    }
}