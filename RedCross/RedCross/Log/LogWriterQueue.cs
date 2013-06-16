using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VeinTestDemo.Log
{
    public class LogWriterQueue
    {
        private LogQueue queue;
        private static LogWriterQueue log_WQ;
        private RecordModel model;
        private object threadLock = new object();

        public static LogWriterQueue Instance()
        {
            if (log_WQ == null)
            {
                log_WQ = new LogWriterQueue();
            }
            return log_WQ;
        }

        private LogWriterQueue()
        {
            queue = LogQueue.Instance();
        }

        public void Info(string className,string methodName,object o)
        {
            model = new RecordModel(DateTime.Now.Date,
                GetHeader(className,methodName,Level.Info) + o.ToString());
            queue.Put(model);
        }

        public void Warn(string className, string methodName, object o)
        {
            model = new RecordModel(DateTime.Now.Date,
                GetHeader(className,methodName, Level.Warn) + o.ToString());
            queue.Put(model);
        }

        public void Error(string className, string methodName, object o)
        {
            model = new RecordModel(DateTime.Now.Date,
                GetHeader(className, methodName, Level.Error) + "********************************" +
                o.ToString() + "********************************");
            queue.Put(model);
        }

        public void Fatal(string className, string methodName, object o)
        {//Serious mistakes, need record immediately 
            string record = 
                GetHeader(className,methodName, Level.Fatal) + o.ToString();
            string fatalFile = Path.Combine(LogWriterFile.Instance().DirectoryPath,"fatal.log");
            using(FileStream fs = new FileStream(fatalFile,FileMode.Append,FileAccess.Write,FileShare.ReadWrite))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(record);
                }
            }
        }

        private string GetHeader(string className, string methodName, Level lev)
        {
            lock(threadLock)
            {
                string header = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":";
                switch (lev)
                {
                    case Level.Info:
                        header += "_Info_,";
                        break;
                    case Level.Warn:
                        header += "_Warn_,";
                        break;
                    case Level.Error:
                        header += "_Error_,";
                        break;
                    case Level.Fatal:
                        header += "_Fatal_,";
                        break;
                }
                header += " " + className + ": " + methodName + ": ";
                return header;
            }
        }
    }
}
