namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string message):this(success)
        {
        }

        public bool Success { get; }

        public string Message { get; set; }
    }
}
