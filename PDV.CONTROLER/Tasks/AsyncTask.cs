using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PDV.VIEW.FRENTECAIXA.Tasks
{
    public class TaskParams
    {
        private List<KeyValuePair<string, object>> values;

        public static TaskParams Create()
        {
            return new TaskParams();
            //TESTE
        }

        public TaskParams Set(string paramName, object paramValue)
        {
            if (values == null)
                values = new List<KeyValuePair<string, object>>();
            values.Add(new KeyValuePair<string, object>(paramName, paramValue));
            return this;
        }

        public DateTime GetDateTime(string key)
        {
            return Convert.ToDateTime(GetValue(key));
        }

        public decimal GetDecimal(string key)
        {
            return decimal.Parse(GetValue(key).ToString());
        }

        public int GetInt(string key)
        {
            return int.Parse(GetValue(key).ToString());
        }

        public bool GetBool(string key)
        {
            return bool.Parse(GetValue(key).ToString());
        }

        public double GetDouble(string key)
        {
            return double.Parse(GetValue(key).ToString());
        }

        public string GetString(string key)
        {
            return GetValue(key).ToString();
        }

        public string[] GetStringArray(string key)
        {
            return (string[])GetValue(key);
        }

        public object GetValue(string key)
        {
            if (values == null)
                throw new Exception("No Keys has stored in this TaskResult instance.");

            return values.FirstOrDefault(r => r.Key == key).Value;
        }
    }

    public class TaskResult
    {
        private List<KeyValuePair<string, object>> values;

        public TaskResult SetValue(string key, object value)
        {
            if (values == null)
                values = new List<KeyValuePair<string, object>>();

            values.Add(new KeyValuePair<string, object>(key, value));
            return this;
        }
        public bool GetBool(string key)
        {
            return bool.Parse(GetValue(key).ToString());
        }

        public decimal GetDecimal(string key)
        {
            return decimal.Parse(GetValue(key).ToString());
        }

        public int GetInt(string key)
        {
            return int.Parse(GetValue(key).ToString());
        }

        public double GetDouble(string key)
        {
            return double.Parse(GetValue(key).ToString());
        }

        public string GetString(string key)
        {
            if (key != null)
                return GetValue(key).ToString();
            else
                return "";
        }

        public string[] GetStringArray(string key)
        {
            return (string[])GetValue(key);
        }

        public object GetValue(string key)
        {
            if (values == null)
                throw new Exception("No Keys has stored in this TaskResult instance.");

            return values.FirstOrDefault(r => r.Key == key).Value;
        }
    }

    public class AsyncTaskCancelException : Exception
    {
        private string message { get; set; }
        public bool InvokeOnPostExecute { get; set; }
        public AsyncTaskCancelException(string message, bool invokeOnPostExecute)
        {
            this.message = message;
            InvokeOnPostExecute = invokeOnPostExecute;
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }

    public abstract class AsyncTask<TParams, TProgress, TReturn>
    {
        public delegate void TaskCompletation(TReturn result);
        public event TaskCompletation OnCompleted;

        private bool Canceled { get; set; }
        private bool InvokeOnPostExecute { get; set; }
        private bool cancelable = false;
        public bool Cancelable
        {
            get
            {
                return cancelable;
            }
            set
            {
                cancelable = value;
                MainWorker.WorkerSupportsCancellation = value;
            }
        }
        private TReturn Result { get; set; }
        private TParams Params { get; set; }
        private BackgroundWorker MainWorker { get; set; }
        private int Progress = 0;
        private List<Tuple<Object, string, object[]>> methodsToInvokeAfterExecute;

        public abstract TReturn DoInBackGround(TParams param);
        public abstract void OnPostExecute(TReturn result);
        public abstract void OnProgressUpdate(TProgress progress);
        public abstract void OnPreExecute();

        public void UpdateProgress(TProgress progress)
        {
            MainWorker.ReportProgress((Progress++), progress);
        }

        public void CancelTask(bool invokeOnPostExecute = false)
        {
            if (!Cancelable)
            {
                //  MessageBox.Show("Uma AsynkTask não pode ser cancelada antes ou após DoInBackground.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Canceled = true;
            InvokeOnPostExecute = invokeOnPostExecute;
            throw new AsyncTaskCancelException("Worker canceled", invokeOnPostExecute);
        }

        public void InvokeAfterExecute(object targetObjectInstance,
            string methodToInvoke, object[] parameters = null)
        {
            if (methodsToInvokeAfterExecute == null)
                methodsToInvokeAfterExecute = new List<Tuple<Object, string, object[]>>();

            methodsToInvokeAfterExecute.Add(new Tuple<Object, string, object[]>(targetObjectInstance,
                methodToInvoke, parameters));
        }

        public virtual void Execute(TParams prms)
        {
            OnPreExecute();
            Params = prms;

            MainWorker = new BackgroundWorker();
            lock (MainWorker)
            {
                MainWorker.WorkerReportsProgress = true;
                MainWorker.DoWork += Worker_DoWork;
                MainWorker.ProgressChanged += Worker_ProgressChanged;
                MainWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                MainWorker.RunWorkerAsync();
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainWorker.Dispose();
            MainWorker = null;

            if (Canceled)
            {
                if (InvokeOnPostExecute)
                {
                    OnPostExecute(Result);
                    OnCompleted?.Invoke(Result);
                }
                return;
            }

            try
            {
                if (methodsToInvokeAfterExecute != null)
                    foreach (Tuple<Object, string, object[]> item in methodsToInvokeAfterExecute)
                        item.Item1.GetType().GetMethod(item.Item2)
                            .Invoke(item.Item1, item.Item3);
            }
            catch { }

            OnCompleted?.Invoke(Result);
            OnPostExecute(Result);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Canceled)
                return;
            OnProgressUpdate((TProgress)e.UserState);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Cancelable = true;
                Result = DoInBackGround(Params);
                Cancelable = false;
            }
            catch (AsyncTaskCancelException ex)
            {
                //nothing
            }
        }
    }
}
