namespace PDV.DAO.Custom
{
    public class MsgRetorno
    {
        public string Type { get; set; }
        public string Msg { get; set; }
        
        public MsgRetorno()
        {
        }

        public MsgRetorno(string TYPE, string MSG)
        {
            Type = TYPE;
            Msg = MSG;
        }
    }
}
