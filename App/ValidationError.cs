using System.ComponentModel.DataAnnotations;

public class ValidationError
{
    public string? type { get; set; }
    public string? title { get; set; }
    public int? status { get; set; }
    public Dictionary<string, string[]>? errors { get; set; }
    public string? traceId { get; set; }
}