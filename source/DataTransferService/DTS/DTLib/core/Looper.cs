using System;
using System.Collections.Generic;
using System.Threading;

namespace DTLib.core
{
    public class Looper
    {
        public Looper()
        {
            this.Msgs = new Queue<Message>();
            this.waitevent = new ManualResetEvent(true);
            this.taskScheduler = new core.TaskScheduler();
        }

        public void loop()
        {
            this.Context = new Thread(() =>
            {
                while (waitevent.WaitOne())
                {
                    lock (this.Msgs)
                    {
                        if (this.Msgs.Count > 0)
                        {
                            Message msg = this.Msgs.Dequeue();
                            if (msg.handler != null)
                            {
                                if ( msg.WorkMode == WorkMode.ThreadPool)
                                {
                                    ThreadPool.QueueUserWorkItem(new WaitCallback((t) => msg.handler()));
                                }
                                else if ( msg.WorkMode == WorkMode.TaskScheduler)
                                {
                                    this.taskScheduler.AddTask(msg.handler);
                                }
                            }
                            else if (msg.Msg == "exit")
                            {
                                Console.WriteLine("exit");
                                break;
                            }
                            else
                                this.HandleMessage(msg);
                        }
                        if (this.Msgs.Count == 0)
                            this.waitevent.Reset();
                    }
                }
            });
            this.Context.Start();
        }

        public void SendMsg(Message msg)
        {
            lock(this.Msgs)
            {
                this.Msgs.Enqueue(msg);
                this.waitevent.Set();
            }
        }

        public virtual void HandleMessage(Message msg)
        {
            Console.WriteLine("invalid message");
        }

        public Queue<Message> Msgs { get; private set; }
        private Thread Context { get; set; }

        private ManualResetEvent waitevent;
        private TaskScheduler taskScheduler;
    }
}
