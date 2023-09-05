using System.Text.Json.Serialization;
using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Common.Wrapper.Concrete
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T Data { get; }
        public bool Success { get; } = true;

        public int StatusCode { get; }
        public string Message { get; set; }

        [JsonConstructor]
        public DataResponse(T data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public DataResponse(T data, int statudCode, string message) 
        {
            Data = data;
            StatusCode = statudCode;
            Message = message;
        }
    }
}
