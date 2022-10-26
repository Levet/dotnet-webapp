namespace Classes
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string Error { get; }

        protected Result(bool isSuccess, T value, string error)
        {
            if (isSuccess && value == null)
                throw new ArgumentNullException(nameof(value));
            if (!isSuccess && string.IsNullOrWhiteSpace(error))
                throw new ArgumentException("Error message is required for failures.", nameof(error));

            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<T> Ok(T value) => new Result<T>(true, value, null);

        public static Result<T> Fail(string error) => new Result<T>(false, default(T), error);
    }
}