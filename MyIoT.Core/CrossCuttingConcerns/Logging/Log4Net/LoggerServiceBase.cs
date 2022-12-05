//System
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
}

