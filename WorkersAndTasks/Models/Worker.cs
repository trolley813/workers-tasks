using System.ComponentModel.DataAnnotations;

namespace WorkersAndTasks.Models;

public class Worker
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Skill level must be between 1 and 5")]
    public int SkillLevel { get; set; }
    [Required]
    public AvailableRange AvailableRange { get; set; }

    public DateTime GetAvailableStartTime(DateTime from)
    {
        if (AvailableRange.AvailableAt(from))
            return from;
        var startTime = from.Date + AvailableRange.StartTime.ToTimeSpan();
        return startTime < from ? startTime.AddDays(1) : startTime;
    }
    
    public DateTime GetFinishTime(DateTime from, WorkingTask task)
    {
        var finishTime = GetAvailableStartTime(from);
        var adjustedDuration =  task.Duration / SkillLevel;
        while (adjustedDuration > 0)
        {
             var t = finishTime.AddMinutes(adjustedDuration);
             // если укладываемся до конца текущего дня
             if (AvailableRange.AvailableAt(t))
             {
                 return t;
             }
             // иначе делаем столько, сколько возможно, остальное откладываем на следующий день
             var d = AvailableRange.GetRemainingFreeMinutes(finishTime);
             finishTime = GetAvailableStartTime((finishTime.AddMinutes(d).AddSeconds(1)));
             adjustedDuration -= d;
        }
        return finishTime;
    }
}