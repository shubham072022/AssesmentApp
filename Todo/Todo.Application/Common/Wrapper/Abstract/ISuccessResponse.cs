namespace Todo.Application.Common.Wrapper.Abstract
{
    public interface ISuccessResponse : IResponse
    {
        string Message { get; }
    }
}
