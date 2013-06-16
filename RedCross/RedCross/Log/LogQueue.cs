using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VeinTestDemo.Log;

namespace VeinTestDemo
{
    public class LogQueue
    {
        public Queue queue;
        private static LogQueue logQueue;
        private RecordModel record;
        private object threadLock = new object();

        public static LogQueue Instance()
        {
            if (logQueue == null)
            {
                logQueue = new LogQueue();
            }
            return logQueue;
        }

        public LogQueue()
        {
            queue = new Queue();
        }

        public RecordModel Get()
        {
            lock (threadLock)
            {
                if (queue.Count > 0)
                {
                    record = (RecordModel)queue.Dequeue();
                    return record;
                }
                return null;
            }
        }

        public void Put(RecordModel record)
        {
            lock (threadLock)
            {
                if (queue.Count > 1000)
                {
                    queue.Dequeue();
                }
                queue.Enqueue(record);
            }
        }

        public void Clear()
        {
            lock (threadLock)
            {
                if (queue.Count > 0)
                {
                    queue.Clear();
                }
            }
        }
    }
}
