
namespace clean_arch.Service.DTOs.Base
{
    public class ResultResponse<T> where T : class
    {
        public bool Success
        {
            get { return this.Error == null; }
        }
        public ResponseError Error { get; private set; } = null!;

        public T? Data { get; private set; } = null;

        public void AddError(Exception exception, string customMessage)
        {
            this.Error ??= new ResponseError(ResponseErrorType.InternalError, customMessage, exception.Message);
        }

        public void AddError(ResponseErrorType type, string customMessage)
        {
            this.Error ??= new ResponseError(type, customMessage);
        }
        public void AddError(ResponseError error)
        {
            this.Error ??= error;
        }
        public void AddError(IEnumerable<ResponseError> errors)
        {
            var internalErrors = errors.Select(f => f.CustomMessage);
            this.AddError(ResponseErrorType.InternalError, string.Join(';', internalErrors));
        }
        public void AddData(T data) { this.Data = data; }
    }
}
