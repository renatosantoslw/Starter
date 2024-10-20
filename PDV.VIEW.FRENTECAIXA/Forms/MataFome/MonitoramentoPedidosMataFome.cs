using ModelAndroidApp.ModelAndroid;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Sequence = PDV.DAO.DB.Utils.Sequence;

namespace PDV.VIEW.FRENTECAIXA.Forms.MataFome
{
    public static class MonitoramentoPedidosMataFome
    {
        public class Log
        {
            public DateTime DataHora { get; set; }
            public string Mensagem { get; set; }
        }
        public static class WSMonitoramento
        {
            private static BindingList<Log> _Log { get; set; }
            public static BindingList<Log> Log
            {
                get
                {
                    if (_Log == null)
                    {
                        _Log = new BindingList<Log>();
                        _Log.AllowEdit = false;
                        _Log.AllowNew = true;
                        _Log.AllowRemove = true;
                    }

                    return _Log;
                }
                set
                {
                    _Log = value;
                }
            }

            public static void AddLog(string msg)
            {
                AddLog(new Log() { DataHora = DateTime.Now, Mensagem = msg });

            }
            public static void AddLog(Log log)
            {
                try
                {
                    Log.Add(log);

                    if (Log.Count > 220)
                    {
                        Log = new BindingList<Log>(Log.ToList());
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public static void RunMonitoramento()
        {

            try
            {
                WSMonitoramento.AddLog("Iniciando Atualização...");
                AtualizarAPP();
                Thread.Sleep(10000);
                WSMonitoramento.AddLog("Atualização da base do aplicativo foi atualizada com sucesso!");
                System.Threading.Tasks.Task.Run((Action)(RunMonitoramento));
            }
            catch (Exception ex)
            {
                WSMonitoramento.AddLog($"Ocorreu um erro :{ex.Message}");
            }
        }
        public static DAO.Entidades.PDV.Venda Venda = null;
        public static List<ItemVenda> lstItemDeVenda = null;
        public static List<DuplicataNFCe> lstPagamentos = null;
        public static DAO.Entidades.Cliente Cliente = null;
        public static void AtualizarAPP()
        {
         
        }
    }
}
