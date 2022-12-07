namespace MyIoT.Core.Utilities.Result;

public static class ResultManager
{
    public static string ReturnApiResult(IResult result)
    {
        return result.Message;
    }

    public static  (T,string) ReturnApiDataResult<T>(IDataResult<T> result)
    {
        if (result.Success)
        {
            return (result.Data,result.Message);
        }
        else
        {
            return (default(T) , result.Message);
        }

    }
}

