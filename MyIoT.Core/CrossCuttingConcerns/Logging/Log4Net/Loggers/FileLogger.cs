using System;
namespace MyIoT.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

public class FileLogger : LoggerServiceBase
{
    public FileLogger(string name) : base("JsonFileLogger")
    {
    }
}
