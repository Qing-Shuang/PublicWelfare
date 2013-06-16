using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using VeinTestDemo.Log;

namespace VeinTestDemo
{
    public class LogWriterFile
    {
        private DateTime fileCreateDate;
        private string directoryPath = null;
        private string filePath = null;
        private FileStream fs = null;
        private StreamWriter sw = null;
        private Thread t_Run;
        private LogQueue queue;
        private static LogWriterFile log_WF;
        private object threadlock = new object();

        public string DirectoryPath
        {
            get 
            {
                if (!string.IsNullOrEmpty(directoryPath))
                {
                    return directoryPath;
                }
                return null; 
            }
        }

        public Thread Run_Thread
        {
            get
            {
                if (t_Run == null)
                {
                    t_Run = new Thread(new ThreadStart(Run));
                    t_Run.Name = "LogWriterFile";
                }
                return t_Run;
            }
        }

        public static LogWriterFile Instance()
        {
            if (log_WF == null)
            {
                log_WF = new LogWriterFile();
            }
            return log_WF;
        }

        private LogWriterFile()
        {
            CreateFile();
            queue = LogQueue.Instance();
        }

        private void CreateFile()
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            this.fileCreateDate = DateTime.Now.Date;

            //this.directoryPath = Path.Combine("/Log");
            Directory.CreateDirectory(directoryPath);

            this.filePath = Path.Combine(directoryPath, fileName);
        }

        private void Write(RecordModel model)
        {
            CompareRecordDate(model);
            if (sw != null)
            {
                sw.Close();
            }
            if (fs != null)
            {
                fs.Close();
            }

            //Console.WriteLine("Using Writer");
            using (fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (sw = new StreamWriter(fs))
                {
                    sw.WriteLine(model.Record);
                }
            }
        }

        private void CompareRecordDate(RecordModel model)
        {
            if (model.DTime.Date != fileCreateDate.Date)
            {
                CreateFile();
            }
        }

        private void Run()
        {
            while (true)
            {
                RecordModel record = queue.Get();
                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":" + "Thread is " + Thread.CurrentThread.Name);
                if (record != null)
                {
                    Write(record);
                }
                Thread.Sleep(500);
            }
        }

        public void Close()
        {
            if (sw != null)
            {
                sw.Close();
            }
            if (fs != null)
            {
                fs.Close();
            }
            if (t_Run != null && t_Run.ThreadState != ThreadState.Stopped)
            {
                t_Run.Abort();
            }
        }
    }
}
