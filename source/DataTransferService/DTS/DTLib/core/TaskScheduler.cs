using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLib.core
{
    internal class TaskScheduler
    {
        public TaskScheduler()
        {
            this.factory = new TaskFactory();
            this.tasks = new Dictionary<int, Task>();
        }

        public void AddTask(Action action)
        {
            lock (this.tasks)
            {
                Task task = this.factory.StartNew(action);
                tasks.Add(task.Id, task);
            }
        }
        public  Dictionary<int, Task> tasks { get; private set; }

        private TaskFactory factory;
    }
}
