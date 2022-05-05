public class Response{
    public Response(){}
    public Response(object? jsonData=null, bool isSuccess=true, string message="None."){
        Success = isSuccess;
        Message = message;
        JsonData = jsonData;
    }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "None.";
    public object? JsonData {get; set;} = null;
}