namespace API.Errors;

<<<<<<< HEAD
public class ApiException(int StatusCode, string message, string? details)
{
    public int StatusCode { get; set; } = StatusCode;
    public string Message { get; set; } = message;
    public string? Details { get; set; } = details;
}


=======
public class ApiException(int statusCode, string message, string? details)
{
    public int StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message;
    public string? Details { get; set; } = details;
}
>>>>>>> datingapp/main
