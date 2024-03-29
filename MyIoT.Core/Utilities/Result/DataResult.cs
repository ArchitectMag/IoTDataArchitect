﻿namespace MyIoT.Core.Utilities.Result;

public class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, bool success, string message) : base(success, message)
    {
        Data = data;
        Message = message;
    }

    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }

    public T Data { get; }

}
