﻿//System
using log4net;
using System.Xml;
using log4net.Repository;
using System.Reflection;

namespace MyIoT.Core.CrossCuttingConcerns.Logging.Log4Net;

public class LoggerServiceBase
{
    private ILog _log;

    public LoggerServiceBase(string name)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(File.OpenRead("log4net.config"));
        ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
        log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);
        _log = LogManager.GetLogger(loggerRepository.Name, name);
    }

    public bool IsInfoEnabled => _log.IsInfoEnabled;
    public bool IsWarnEnabled => _log.IsWarnEnabled;
    public bool IsDebugEnabled => _log.IsDebugEnabled;
    public bool IsFataEnabled => _log.IsFatalEnabled;
    public bool IsErrorEnabled => _log.IsErrorEnabled;

    public void Info(object logMessage)
    {
        if (IsInfoEnabled)
            _log.Info(logMessage);
    }

    public void Warn(object logMessage)
    {
        if (IsWarnEnabled)
            _log.Warn(logMessage);
    }

    public void Debug(object logMessage)
    {
        if (IsDebugEnabled)
            _log.Debug(logMessage);
    }

    public void Fatal(object logMessage)
    {
        if (IsFataEnabled)
            _log.Fatal(logMessage);
    }

    public void Error(object logMessage)
    {
        if (IsErrorEnabled)
            _log.Error(logMessage);
    }
}

