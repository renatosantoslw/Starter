using System;

namespace PDV.DAO.Entidades.Estoque.Transferencia
{
    public class TransferenciaEstoque
    {
        public decimal IDTransferenciaEstoque { get; set; } = -1;
        public DateTime DataTransferencia { get; set; } = DateTime.Now;
        public string Observacao { get; set; }

        public TransferenciaEstoque() { }
    }
}
