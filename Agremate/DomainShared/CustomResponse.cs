namespace Agremate.DomainShared;

public class CustomResponse<T>
{
    public int? Count { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
    public bool Status { get; set; }

    public CustomResponse() { }

    public CustomResponse(T result, bool status = true, string message = "", int? count = null)
    {
        Result = result;
        Status = status;
        Message = message;
        Count = count;
    }

    public static CustomResponse<T> Success(T result, string message = "", int? count = null)
        => new(result, true, message, count);

    public static CustomResponse<T> Fail(string message)
        => new(default!, false, message);
}
