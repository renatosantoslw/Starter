using PDV.VIEW.FRENTECAIXA.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.VIEW.FRENTECAIXA.Task
{
    public class EmitirNFceTask : AsyncTask<TaskParams, string, TaskResult>
    {
        public override TaskResult DoInBackGround(TaskParams param)
        {
            return null;
        }

        public override void OnPostExecute(TaskResult result)
        {
            throw new NotImplementedException();
        }

        public override void OnPreExecute()
        {
            throw new NotImplementedException();
        }

        public override void OnProgressUpdate(string progress)
        {
            throw new NotImplementedException();
        }
    }
}
