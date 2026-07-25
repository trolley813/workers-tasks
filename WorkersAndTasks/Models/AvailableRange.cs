namespace WorkersAndTasks.Models;

public struct AvailableRange
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public bool AvailableAt(TimeOnly time)
    {
        if (StartTime < EndTime)
            return StartTime <= time && time <= EndTime;
        // Ночная работа (например, с 22 до 6)
        else if (EndTime < StartTime)
            return time <= EndTime || time >= StartTime;
        return true;
    }
    
    public bool AvailableAt(DateTime time) => AvailableAt(TimeOnly.FromDateTime(time));

    public double GetRemainingFreeMinutes(DateTime from)
    {
        if (!AvailableAt(from)) return 0;
        var result = EndTime - TimeOnly.FromDateTime(from);
        if (result < TimeSpan.Zero) result = result.Add(TimeSpan.FromDays(1));
        return result.TotalMinutes;
    }

    public override string ToString()
    {
        return $"{StartTime} - {EndTime}";
    }
}