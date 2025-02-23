namespace clean_arch.Api
{
    public class ResultResponse<T> 
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public ICollection<string> Errors { get; set; }

        public ResultResponse(T data, bool success)
        {
            Data = data;
            Success = success;
            Errors = new List<string>();
        }

        public ResultResponse(bool success)
        {
            Success = success;
        }

        public ResultResponse(string error)
        {
            Success = false;
            Errors = new List<string>() { error };
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
