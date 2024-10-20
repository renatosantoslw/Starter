using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CFeImpressao
{
    public class ReportDataSource
    {
        public string Name { get; set; }
        public System.Collections.IEnumerable IEnumerable { get; set; }
        public DataTable DataTable { get; set; }

        public SOURCE_TYPE Source_Type { get; set; }

        public enum SOURCE_TYPE
        {
            IEnumerable = 0,
            DataTable = 1
        }
    }
}
