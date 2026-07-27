using System.ComponentModel.DataAnnotations;

namespace WorkersAndTasks.Models;

public class WorkingTask
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Range(0, double.MaxValue,  ErrorMessage = "Duration must be a positive number")]
    public double Duration { get; set; }
    [Required]
    [Range(1, 3, ErrorMessage =  "Priority must be between 1 and 3")]
    public int Priority { get; set; }
}