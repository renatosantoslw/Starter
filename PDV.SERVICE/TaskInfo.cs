using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PDV.SERVICE
{
    public class TaskInfo
    {
        private RegisteredWaitHandle handle;
        private string info;
        private AutoResetEvent taskEvent;
        private DateTime created;
        private DateTime lastExecution;
        private bool isExecuting;
        private int idCliente;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public TaskInfo(string info)
        {
            this.info = info;
            this.created = DateTime.Now;
            this.taskEvent = new AutoResetEvent(false);
        }

        public TaskInfo(string info, int idCliente)
        {
            this.info = info;
            this.created = DateTime.Now;
            this.taskEvent = new AutoResetEvent(false);
            this.IdCliente = idCliente;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastExecution
        {
            get { return lastExecution; }
            set { lastExecution = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public RegisteredWaitHandle Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AutoResetEvent TaskEvent
        {
            get { return taskEvent; }
            set { taskEvent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsExecuting
        {
            get { return isExecuting; }
            set { isExecuting = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
    }
}
