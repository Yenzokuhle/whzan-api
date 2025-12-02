namespace Whzan_API.DTOs.Response
{
    public class DataResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public bool IsSuccess { get; set; }
    }
}
