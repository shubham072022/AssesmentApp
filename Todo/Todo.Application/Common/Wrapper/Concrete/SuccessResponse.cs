using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Common.Wrapper.Concrete
{
    public class SuccessResponse : ISuccessResponse
    {
        public bool Success { get; } = true;
        public string Message { get; }
        public int StatusCode { get; }

        public SuccessResponse()
        {

        }

        public SuccessResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
