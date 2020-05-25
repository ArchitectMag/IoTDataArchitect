namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(success:true)
        {
        }
        public SuccessResult(string message) : base(success:true, message)
        {
        }
    }
}
