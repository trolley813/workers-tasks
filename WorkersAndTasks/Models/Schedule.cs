namespace WorkersAndTasks.Models;

public class ScheduleItem
{
    public int WorkerId { get; set; }
    public int TaskId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
}

public class Schedule
{
    public DateTime FinishTime { get; set; }
    public List<ScheduleItem> Items { get; set; } = [];
}