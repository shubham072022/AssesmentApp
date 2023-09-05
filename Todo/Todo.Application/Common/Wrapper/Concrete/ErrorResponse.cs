using Todo.Application.Common.Wrapper.Abstract;

namespace Todo.Application.Common.Wrapper.Concrete
{
    public class ErrorResponse : IErrorResponse
    {
        public bool Success { get; } = false;
        public int StatusCode { get; }
        public List<string> Errors { get; private set; } = new List<string>();

        public ErrorResponse(int statusCode,List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public ErrorResponse(int statusCode, string error) 
        {
            StatusCode=statusCode;
            Errors.Add(error);
        }
    }
}
