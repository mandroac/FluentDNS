namespace FDNS.Common.Models
{
    public class ServiceResult<T>
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResult(T value)
        {
            Value = value;
            IsSuccess = true;
        }

        public ServiceResult(List<string> errors)
        {
            Errors = errors;
            IsSuccess = false;
        }
    }
}
