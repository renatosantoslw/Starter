using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.UTIL.Components.Custom
{
    public class EditDecimal : NumericUpDown
    {
        public decimal viTamanho { get; set; } = 15;
        public decimal viPrecisao { get; set; } = 2;
        public string Sigla { get; set; } = "**";
        public decimal vdValorDecimal { get; set; } = 0;

        private Label mLabel;
        private TextBox mBox;

        public EditDecimal()
        {
            UpDownAlign = LeftRightAlignment.Left;
            Controls.RemoveAt(0);
            mBox = Controls[0] as TextBox;
            mBox.Enabled = true;
            mBox.BackColor = Color.White;
            mLabel = new Label();
            mLabel.Text = Sigla;
            mLabel.ForeColor = Color.White;
            mLabel.Font = new Font("Open Sans", 10, FontStyle.Regular);
            Font = new Font("Open Sans", 10, FontStyle.Regular);
            TextAlign = HorizontalAlignment.Right;
            mLabel.Location = new Point(1, 1);
            mLabel.Width = 30;
            mLabel.Height = Height + 3;
            mLabel.Padding = new Padding(0, 3, 0, 0);
            Controls.Add(mLabel);
            mLabel.BringToFront();
            mLabel.BackColor = Color.Gray;
            Select(0, 1000);
            BorderStyle = BorderStyle.FixedSingle;
        }

        private string GerarCaracteres(int Tamanho)
        {
            List<int> Inteiros = new List<int>();
            for (int i = 0; i < Tamanho; i++)
                Inteiros.Add(9);

            return string.Join(string.Empty, Inteiros);
        }

        private string GetNumeroMontado()
        {
            return $"{GerarCaracteres(Convert.ToInt32(viTamanho - viPrecisao))},{GerarCaracteres(Convert.ToInt32(viPrecisao))}";
        }

        public void AplicaAlteracoes()
        {
            Maximum = Convert.ToDecimal(GetNumeroMontado());
            DecimalPlaces = Convert.ToInt32(viPrecisao);
            ThousandsSeparator = true;

            mBox = Controls[0] as TextBox;
            mLabel.Text = Sigla;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            AplicaAlteracoes();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Select(0, 1000);
        }
    }
}
