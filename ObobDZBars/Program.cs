using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObobDZBars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обобщение
            LocalFileLogger<int> localFileLoggerInt = new LocalFileLogger<int>(@"D:\Test.txt");
            localFileLoggerInt.LogInfo("Info");
            localFileLoggerInt.LogWarning("WARNING");
            localFileLoggerInt.LogError("EROR", new Exception());

            LocalFileLogger<string> localFileLoggerString = new LocalFileLogger<string>(@"D:\Test.txt");
            localFileLoggerString.LogInfo("Info");
            localFileLoggerString.LogWarning("WARNING");
            localFileLoggerString.LogError("EROR", new Exception());

            LocalFileLogger<float> localFileLoggerFloat = new LocalFileLogger<float>(@"D:\Test.txt");
            localFileLoggerFloat.LogInfo("Info");
            localFileLoggerFloat.LogWarning("WARNING");
            localFileLoggerFloat.LogError("EROR", new Exception());

            Console.WriteLine("Все понял, все записал");

            //Коллекция 
            List<Entity> ts = Entity.ListRet();
            Dictionary<int, List<Entity>> valuePairs = Entity.ValuePairs(ts);
        }
    }

    interface ILogger
    {
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message, Exception ex);

    }

    class LocalFileLogger<T> : ILogger
    {
        string path;
        public LocalFileLogger(string reference)
        {
            path = reference;
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(path, $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}" + Environment.NewLine + Environment.NewLine);
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(path, $"[Info]: [{typeof(T).Name}] : {message}" + Environment.NewLine);
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(path, $"[Info]: [{typeof(T).Name}] : {message}" + Environment.NewLine );
        }
    }
}
