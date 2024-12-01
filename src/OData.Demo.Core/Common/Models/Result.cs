namespace OData.Demo.Core.Common.Models
{
    public class Result<T>
    {
        public bool Succeeded { get; private set; }
        public T? Value { get; private set; }
        public string[] Errors { get; private set; }

        private Result(bool succeeded, T? value, string[] errors)
        {
            Succeeded = succeeded;
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new(true, value, Array.Empty<string>());

        public static Result<T> Failure(params string[] errors) => new(false, default, errors);
    }
}