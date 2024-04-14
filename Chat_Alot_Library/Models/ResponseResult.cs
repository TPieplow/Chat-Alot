namespace Chat_Alot_Library.Models;

public enum StatusCode
{
    OK = 200,
    ERROR = 400,
    NOUT_FOUND = 404,
    EXISTS = 409,
    EXTERNAL_ERROR = 500,
    INTERNAL_ERROR = 501
}
public class ResponseResult
{
    public StatusCode Status { get; set; }
    public object? ContentResult { get; set; }
    public string? Message { get; set; }
}
