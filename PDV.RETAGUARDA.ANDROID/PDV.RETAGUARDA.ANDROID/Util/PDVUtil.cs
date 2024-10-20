using PDV.DAO.Enum;
using System;
using System.Data;
using System.Web;

namespace PDV.RETAGUARDA.WEB.Util
{
    public class PDVUtil
    {
        public static string AppUrl
        {
            get
            {
                string appPath = null;
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    appPath = string.Format("{0}://{1}{2}{3}",
                      context.Request.Url.Scheme,
                      context.Request.Url.Host,
                      context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port,
                      context.Request.ApplicationPath);
                }

                if (!appPath.EndsWith("/"))
                    appPath += "/";

                return appPath;
            }
        }

        private static IniFile iniFile;
        public static IniFile IniFile
        {
            get
            {
                if (iniFile == null)
                    iniFile = new IniFile(HttpContext.Current.Server.MapPath("~/App_Data/Start.ini"));
                return iniFile;
            }
        }

        public static DataTable GetChanges(DataTable dt, TipoOperacao to)
        {
            if (dt == null)
                return null;

            switch (to)
            {
                case TipoOperacao.INSERT:
                    return dt.GetChanges(DataRowState.Added);
                case TipoOperacao.UPDATE:
                    return dt.GetChanges(DataRowState.Modified);
                case TipoOperacao.DELETE:
                    using (DataTable dtDel = dt.GetChanges(DataRowState.Deleted))
                    {
                        if (dtDel == null)
                            return null;
                        dtDel.RejectChanges();
                        return dtDel;
                    }
                default:
                    return null;
            }
        }

        public static string[] GetPathInfo(HttpRequest Request, bool toLower = false)
        {
            return Request.PathInfo.Length > 0 ? (toLower ? Request.PathInfo.ToLower() : Request.PathInfo).Substring(1).Replace(".", string.Empty).Split('/') : new string[0];
        }
    }

    public class DateTimeRange
    {
        private DateTime Start;
        private DateTime End;

        public DateTimeRange(DateTime? start, DateTime? end)
        {
            if (!start.HasValue)
                start = DateTime.MinValue;
            this.Start = start.Value;

            if (!end.HasValue)
                end = DateTime.MaxValue;
            this.End = end.Value;
        }

        public bool Overlap(DateTimeRange test)
        {
            return !(this.Start > test.End || test.Start > this.End);
        }

        public bool Intersect(DateTimeRange test)
        {
            return (this.Start > test.End || test.Start > this.End);
        }
    }

}