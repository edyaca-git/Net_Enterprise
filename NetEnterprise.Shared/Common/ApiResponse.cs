namespace NetEnterprise.Shared.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public DateTime Timestamp { get; set; }
    public IDictionary<string, string[]>? Errors { get; set; }

    public ApiResponse()
    {
        Timestamp = DateTime.UtcNow;
    }

    public ApiResponse(T data, string? message = null)
    {
        Success = true;
        Data = data;
        Message = message;
        StatusCode = 200;
        Timestamp = DateTime.UtcNow;
    }

    public static ApiResponse<T> SuccessResponse(T data, string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message,
            StatusCode = 200,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> ErrorResponse(
        string message,
        int statusCode = 400,
        IDictionary<string, string[]>? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            StatusCode = statusCode,
            Errors = errors,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> CreatedResponse(T data, string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message ?? "Registro creado exitosamente",
            StatusCode = 201,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ApiResponse<T> NotFoundResponse(string? message = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message ?? "Recurso no encontrado",
            StatusCode = 404,
            Timestamp = DateTime.UtcNow
        };
    }
}