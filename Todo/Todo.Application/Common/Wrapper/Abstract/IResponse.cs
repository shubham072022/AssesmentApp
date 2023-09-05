namespace Todo.Application.Common.Wrapper.Abstract
{
    public interface IResponse
    {
        bool Success { get; }
        int StatusCode { get; }
    }
}
