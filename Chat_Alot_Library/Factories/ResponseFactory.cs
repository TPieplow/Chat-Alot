using Chat_Alot_Library.Models;

namespace Chat_Alot_Library.Factories;

public class ResponseFactory
{
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {
            Message = "OK",
            Status = StatusCode.OK,
        };
    }

    public static ResponseResult Ok(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "OK",
            Status = StatusCode.OK,
        };
    }

    public static ResponseResult Ok(object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "OK",
            Status = StatusCode.OK,
        };
    }

    public static ResponseResult Error(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "ERROR",
            Status = StatusCode.ERROR,
        };
    }

    public static ResponseResult InternalError(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "ERROR",
            Status = StatusCode.INTERNAL_ERROR,
        };
    }

    public static ResponseResult ExternalError(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "ERROR",
            Status = StatusCode.EXTERNAL_ERROR,
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not found",
            Status = StatusCode.NOUT_FOUND,
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Already exists",
            Status = StatusCode.EXISTS,
        };
    }
}
