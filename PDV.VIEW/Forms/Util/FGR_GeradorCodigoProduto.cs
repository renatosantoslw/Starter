using MetroFramework;
using MetroFramework.Forms;
using PDV.VIEW.Forms.Cadastro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Util
{

    public partial class FGR_GeradorCodigoProduto : DevExpress.XtraEditors.XtraForm
    {
        public class Ean13
        {
            private string _sName = "EAN13";

            private float _fMinimumAllowableScale = .8f;
            private float _fMaximumAllowableScale = 2.0f;

            // Este é o tamanho nominal recomendado pela EAN.
            private float _fWidth = 37.29f;
            private float _fHeight = 25.93f;
            private float _fFontSize = 8.0f;
            private float _fScale = 1.0f;

            // Dígitos mão esquersa
            private string[] _aOddLeft = { "0001101", "0011001", "0010011", "0111101",
                                          "0100011", "0110001", "0101111", "0111011",
                                          "0110111", "0001011" };

            private string[] _aEvenLeft = { "0100111", "0110011", "0011011", "0100001",
                                           "0011101", "0111001", "0000101", "0010001",
                                           "0001001", "0010111" };

            // Dígitos mão direita
            private string[] _aRight = { "1110010", "1100110", "1101100", "1000010",
                                        "1011100", "1001110", "1010000", "1000100",
                                        "1001000", "1110100" };

            private string _sQuiteZone = "000000000";

            private string _sLeadTail = "101";

            private string _sSeparator = "01010";

            private string _sCountryCode = "00";
            private string _sManufacturerCode;
            private string _sProductCode;
            private string _sChecksumDigit;

            public Ean13()
            {

            }

            public Ean13(string mfgNumber, string productId)
            {
                this.CountryCode = "00";
                this.ManufacturerCode = mfgNumber;
                this.ProductCode = productId;
                this.CalculateChecksumDigit();
            }

            public Ean13(string countryCode, string mfgNumber, string productId)
            {
                this.CountryCode = countryCode;
                this.ManufacturerCode = mfgNumber;
                this.ProductCode = productId;
                this.CalculateChecksumDigit();
            }

            public Ean13(string countryCode, string mfgNumber, string productId, string checkDigit)
            {
                this.CountryCode = countryCode;
                this.ManufacturerCode = mfgNumber;
                this.ProductCode = productId;
                this.ChecksumDigit = checkDigit;
            }

            public void DrawEan13Barcode(System.Drawing.Graphics g, System.Drawing.Point pt)
            {
                float width = this.Width * this.Scale;
                float height = this.Height * this.Scale;

                //	EAN13 Barcode should be a total of 113 modules wide.
                float lineWidth = width / 113f;

                // Save the GraphicsState.
                System.Drawing.Drawing2D.GraphicsState gs = g.Save();

                // Set the PageUnit to Inch because all of our measurements are in inches.
                g.PageUnit = System.Drawing.GraphicsUnit.Millimeter;

                // Set the PageScale to 1, so a millimeter will represent a true millimeter.
                g.PageScale = 1;

                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

                float xPosition = 0;

                System.Text.StringBuilder strbEAN13 = new System.Text.StringBuilder();
                System.Text.StringBuilder sbTemp = new System.Text.StringBuilder();

                float xStart = pt.X;
                float yStart = pt.Y;
                float xEnd = 0;

                Font font = new Font("Arial", this._fFontSize * this.Scale);

                // Calculate the Check Digit.
                this.CalculateChecksumDigit();

                sbTemp.AppendFormat("{0}{1}{2}{3}",
                    this.CountryCode,
                    this.ManufacturerCode,
                    this.ProductCode,
                    this.ChecksumDigit);


                string sTemp = sbTemp.ToString();

                string sLeftPattern = "";

                // Convert the left hand numbers.
                sLeftPattern = ConvertLeftPattern(sTemp.Substring(0, 7));

                // Build the UPC Code.
                strbEAN13.AppendFormat("{0}{1}{2}{3}{4}{1}{0}",
                    this._sQuiteZone, this._sLeadTail,
                    sLeftPattern,
                    this._sSeparator,
                    ConvertToDigitPatterns(sTemp.Substring(7), this._aRight));

                string sTempUPC = strbEAN13.ToString();

                float fTextHeight = g.MeasureString(sTempUPC, font).Height;

                // Draw the barcode lines.
                for (int i = 0; i < strbEAN13.Length; i++)
                {
                    if (sTempUPC.Substring(i, 1) == "1")
                    {
                        if (xStart == pt.X)
                            xStart = xPosition;

                        // Save room for the UPC number below the bar code.
                        if ((i > 12 && i < 55) || (i > 57 && i < 101))
                            // Draw space for the number
                            g.FillRectangle(brush, xPosition, yStart, lineWidth, height - fTextHeight);
                        else
                            // Draw a full line.
                            g.FillRectangle(brush, xPosition, yStart, lineWidth, height);
                    }

                    xPosition += lineWidth;
                    xEnd = xPosition;
                }

                // Draw the upc numbers below the line.
                xPosition = xStart - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
                float yPosition = yStart + (height - fTextHeight);

                // Draw 1st digit of the country code.
                g.DrawString(sTemp.Substring(0, 1), font, brush, new System.Drawing.PointF(xPosition, yPosition));

                xPosition += (g.MeasureString(sTemp.Substring(0, 1), font).Width + 43 * lineWidth) -
                    (g.MeasureString(sTemp.Substring(1, 6), font).Width);

                // Draw MFG Number.
                g.DrawString(sTemp.Substring(1, 6), font, brush, new System.Drawing.PointF(xPosition, yPosition));

                xPosition += g.MeasureString(sTemp.Substring(1, 6), font).Width + (11 * lineWidth);

                // Draw Product ID.
                g.DrawString(sTemp.Substring(7), font, brush, new System.Drawing.PointF(xPosition, yPosition));

                // Restore the GraphicsState.
                g.Restore(gs);
            }


            public System.Drawing.Bitmap CreateBitmap()
            {
                float tempWidth = (this.Width * this.Scale) * 100;
                float tempHeight = (this.Height * this.Scale) * 100;

                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap((int)tempWidth, (int)tempHeight);

                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                this.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
                g.Dispose();
                return bmp;
            }


            private string ConvertLeftPattern(string sLeft)
            {
                switch (sLeft.Substring(0, 1))
                {
                    case "0":
                        return CountryCode0(sLeft.Substring(1));

                    case "1":
                        return CountryCode1(sLeft.Substring(1));

                    case "2":
                        return CountryCode2(sLeft.Substring(1));

                    case "3":
                        return CountryCode3(sLeft.Substring(1));

                    case "4":
                        return CountryCode4(sLeft.Substring(1));

                    case "5":
                        return CountryCode5(sLeft.Substring(1));

                    case "6":
                        return CountryCode6(sLeft.Substring(1));

                    case "7":
                        return CountryCode7(sLeft.Substring(1));

                    case "8":
                        return CountryCode8(sLeft.Substring(1));

                    case "9":
                        return CountryCode9(sLeft.Substring(1));

                    default:
                        return "";
                }
            }


            private string CountryCode0(string sLeft)
            {
                // 0 Odd Odd  Odd  Odd  Odd  Odd 
                return ConvertToDigitPatterns(sLeft, this._aOddLeft);
            }


            private string CountryCode1(string sLeft)
            {
                // 1 Odd Odd  Even Odd  Even Even 
                System.Text.StringBuilder sReturn = new StringBuilder();
                // The two lines below could be replaced with this:
                // sReturn.Append( ConvertToDigitPatterns( sLeft.Substring( 0, 2 ), this._aOddLeft ) );
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
                // The two lines below could be replaced with this:
                // sReturn.Append( ConvertToDigitPatterns( sLeft.Substring( 4, 2 ), this._aEvenLeft ) );
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
                return sReturn.ToString();
            }


            private string CountryCode2(string sLeft)
            {
                // 2 Odd Odd  Even Even Odd  Even 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
                return sReturn.ToString();
            }


            private string CountryCode3(string sLeft)
            {
                // 3 Odd Odd  Even Even Even Odd 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
                return sReturn.ToString();
            }


            private string CountryCode4(string sLeft)
            {
                // 4 Odd Even Odd  Odd  Even Even 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
                return sReturn.ToString();
            }


            private string CountryCode5(string sLeft)
            {
                // 5 Odd Even Even Odd  Odd  Even 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
                return sReturn.ToString();
            }


            private string CountryCode6(string sLeft)
            {
                // 6 Odd Even Even Even Odd  Odd 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
                return sReturn.ToString();
            }


            private string CountryCode7(string sLeft)
            {
                // 7 Odd Even Odd  Even Odd  Even
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
                return sReturn.ToString();
            }


            private string CountryCode8(string sLeft)
            {
                // 8 Odd Even Odd  Even Even Odd 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
                return sReturn.ToString();
            }


            private string CountryCode9(string sLeft)
            {
                // 9 Odd Even Even Odd  Even Odd 
                System.Text.StringBuilder sReturn = new StringBuilder();
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
                sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
                return sReturn.ToString();
            }


            private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
            {
                System.Text.StringBuilder sbTemp = new StringBuilder();
                int iIndex = 0;
                for (int i = 0; i < inputNumber.Length; i++)
                {
                    iIndex = Convert.ToInt32(inputNumber.Substring(i, 1));
                    sbTemp.Append(patterns[iIndex]);
                }
                return sbTemp.ToString();
            }


            public void CalculateChecksumDigit()
            {
                string sTemp = this.CountryCode + this.ManufacturerCode + this.ProductCode;
                int iSum = 0;
                int iDigit = 0;

                // Calculate the checksum digit here.
                for (int i = sTemp.Length; i >= 1; i--)
                {
                    iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                    if (i % 2 == 0)
                    {   // odd
                        iSum += iDigit * 3;
                    }
                    else
                    {   // even
                        iSum += iDigit * 1;
                    }
                }

                int iCheckSum = (10 - (iSum % 10)) % 10;
                this.ChecksumDigit = iCheckSum.ToString();

            }


            #region -- Attributes/Properties --

            public string Name
            {
                get
                {
                    return _sName;
                }
            }

            public float MinimumAllowableScale
            {
                get
                {
                    return _fMinimumAllowableScale;
                }
            }

            public float MaximumAllowableScale
            {
                get
                {
                    return _fMaximumAllowableScale;
                }
            }

            public float Width
            {
                get
                {
                    return _fWidth;
                }
            }

            public float Height
            {
                get
                {
                    return _fHeight;
                }
            }

            public float FontSize
            {
                get
                {
                    return _fFontSize;
                }
            }

            public float Scale
            {
                get
                {
                    return _fScale;
                }

                set
                {
                    if (value < this._fMinimumAllowableScale || value > this._fMaximumAllowableScale)
                        throw new Exception("Escala do fator fora do intervalo permitido.  Valores devem estar entre " +
                            this._fMinimumAllowableScale.ToString() + " e " +
                            this._fMaximumAllowableScale.ToString());
                    _fScale = value;
                }
            }

            public string CountryCode
            {
                get
                {
                    return _sCountryCode;
                }

                set
                {
                    while (value.Length < 2)
                    {
                        value = "0" + value;
                    }
                    _sCountryCode = value;
                }
            }

            public string ManufacturerCode
            {
                get
                {
                    return _sManufacturerCode;
                }

                set
                {
                    _sManufacturerCode = value;
                }
            }

            public string ProductCode
            {
                get
                {
                    return _sProductCode;
                }

                set
                {
                    _sProductCode = value;
                }
            }

            public string ChecksumDigit
            {
                get
                {
                    return _sChecksumDigit;
                }

                set
                {
                    int iValue = Convert.ToInt32(value);
                    if (iValue < 0 || iValue > 9)
                        throw new Exception("O digito verificador deve estar entre 0 e 9.");
                    _sChecksumDigit = value;
                }
            }

            #endregion -- Attributes/Properties --

        }

        public class CodigoPaisProduto
        {
            public int MinCod { get; set; }
            public int MaxCod { get; set; }
            public string Desc { get; set; }

            public string Format
            {
                get { return string.Format("{0} {1}", MinCod == MaxCod ? MinCod.ToString() : string.Format("{0}-{1}", MinCod, MaxCod), Desc); }
            }

            public CodigoPaisProduto(int MINCOD, int MAXCOD, string DESC)
            {
                MinCod = MINCOD;
                MaxCod = MAXCOD;
                Desc = DESC;
            }
        }

        private Graphics g;
        private Ean13 ean13 = null;
        private FCA_Produtos FORM_PRODUTO = null;
        private string CODIGO_PRODUTO = null;
        private List<CodigoPaisProduto> CODIGOS
        {
            get
            {
                List<CodigoPaisProduto> Cod = new List<CodigoPaisProduto>();
                Cod.Add(new CodigoPaisProduto(00, 13, "EUA e Canadá"));
                Cod.Add(new CodigoPaisProduto(20, 29, "Funções no Armazenamento"));
                Cod.Add(new CodigoPaisProduto(30, 37, "França"));
                Cod.Add(new CodigoPaisProduto(40, 44, "Alemanha"));
                Cod.Add(new CodigoPaisProduto(45, 45, "Japão(também 49)"));
                Cod.Add(new CodigoPaisProduto(46, 46, "Federação Russa"));
                Cod.Add(new CodigoPaisProduto(471, 471, "Taiwan"));
                Cod.Add(new CodigoPaisProduto(474, 474, "Estónia"));
                Cod.Add(new CodigoPaisProduto(475, 475, "Letónia"));
                Cod.Add(new CodigoPaisProduto(477, 477, "Lituânia"));
                Cod.Add(new CodigoPaisProduto(479, 479, "Sri Lanka"));
                Cod.Add(new CodigoPaisProduto(480, 480, "Filipinas"));
                Cod.Add(new CodigoPaisProduto(482, 482, "Ucrânia"));
                Cod.Add(new CodigoPaisProduto(484, 484, "Moldávia"));
                Cod.Add(new CodigoPaisProduto(485, 485, "Armênia"));
                Cod.Add(new CodigoPaisProduto(486, 486, "Geórgia"));
                Cod.Add(new CodigoPaisProduto(487, 487, "Cazaquistão"));
                Cod.Add(new CodigoPaisProduto(489, 489, "Hong Kong"));
                Cod.Add(new CodigoPaisProduto(49, 49, "Japão(JAN - 13)"));
                Cod.Add(new CodigoPaisProduto(50, 50, "Reino Unido"));
                Cod.Add(new CodigoPaisProduto(520, 520, "Grécia"));
                Cod.Add(new CodigoPaisProduto(528, 528, "Líbano"));
                Cod.Add(new CodigoPaisProduto(529, 529, "Chipre"));
                Cod.Add(new CodigoPaisProduto(531, 531, "Macedonia"));
                Cod.Add(new CodigoPaisProduto(535, 535, "Malta"));
                Cod.Add(new CodigoPaisProduto(539, 539, "Irlanda"));
                Cod.Add(new CodigoPaisProduto(54, 54, "Bélgica e Luxemburgo"));
                Cod.Add(new CodigoPaisProduto(560, 560, "Portugal"));
                Cod.Add(new CodigoPaisProduto(569, 569, "Islândia"));
                Cod.Add(new CodigoPaisProduto(57, 57, "Dinamarca"));
                Cod.Add(new CodigoPaisProduto(590, 590, "Polónia"));
                Cod.Add(new CodigoPaisProduto(594, 594, "Roménia"));
                Cod.Add(new CodigoPaisProduto(599, 599, "Hungria"));
                Cod.Add(new CodigoPaisProduto(600, 601, "África do Sul"));
                Cod.Add(new CodigoPaisProduto(609, 609, "Maurícia"));
                Cod.Add(new CodigoPaisProduto(611, 611, "Marrocos"));
                Cod.Add(new CodigoPaisProduto(613, 613, "Argélia"));
                Cod.Add(new CodigoPaisProduto(619, 619, "Tunísia"));
                Cod.Add(new CodigoPaisProduto(622, 622, "Egipto"));
                Cod.Add(new CodigoPaisProduto(625, 625, "Jordânia"));
                Cod.Add(new CodigoPaisProduto(626, 626, "Irã"));
                Cod.Add(new CodigoPaisProduto(64, 64, "Finlândia"));
                Cod.Add(new CodigoPaisProduto(690, 692, "China"));
                Cod.Add(new CodigoPaisProduto(70, 70, "Noruega"));
                Cod.Add(new CodigoPaisProduto(729, 729, "Israel"));
                Cod.Add(new CodigoPaisProduto(73, 73, "Suécia"));
                Cod.Add(new CodigoPaisProduto(740, 740, "Guatemala"));
                Cod.Add(new CodigoPaisProduto(741, 741, "El Salvador"));
                Cod.Add(new CodigoPaisProduto(742, 742, "Honduras"));
                Cod.Add(new CodigoPaisProduto(743, 743, "Nicarágua"));
                Cod.Add(new CodigoPaisProduto(744, 744, "Costa Rica"));
                Cod.Add(new CodigoPaisProduto(746, 746, "República Dominicana"));
                Cod.Add(new CodigoPaisProduto(750, 750, "México"));
                Cod.Add(new CodigoPaisProduto(759, 759, "Venezuela"));
                Cod.Add(new CodigoPaisProduto(76, 76, "Suíça"));
                Cod.Add(new CodigoPaisProduto(770, 770, "Colômbia"));
                Cod.Add(new CodigoPaisProduto(773, 773, "Uruguai"));
                Cod.Add(new CodigoPaisProduto(775, 775, "Perú"));
                Cod.Add(new CodigoPaisProduto(777, 777, "Bolívia"));
                Cod.Add(new CodigoPaisProduto(779, 779, "Argentina"));
                Cod.Add(new CodigoPaisProduto(780, 780, "Chile"));
                Cod.Add(new CodigoPaisProduto(784, 784, "Paraguai"));
                Cod.Add(new CodigoPaisProduto(785, 785, "Peru"));
                Cod.Add(new CodigoPaisProduto(786, 786, "Equador"));
                Cod.Add(new CodigoPaisProduto(789, 789, "Brazil"));
                Cod.Add(new CodigoPaisProduto(80, 83, "Itália"));
                Cod.Add(new CodigoPaisProduto(84, 84, "Espanha"));
                Cod.Add(new CodigoPaisProduto(850, 850, "Cuba"));
                Cod.Add(new CodigoPaisProduto(858, 858, "Eslováquia"));
                Cod.Add(new CodigoPaisProduto(859, 859, "República Checa"));
                Cod.Add(new CodigoPaisProduto(860, 860, "Yugloslavia"));
                Cod.Add(new CodigoPaisProduto(869, 869, "Turquia"));
                Cod.Add(new CodigoPaisProduto(87, 87, "Holanda"));
                Cod.Add(new CodigoPaisProduto(880, 880, "Coreia do Sul"));
                Cod.Add(new CodigoPaisProduto(885, 885, "Tailândia"));
                Cod.Add(new CodigoPaisProduto(888, 888, "Singapura"));
                Cod.Add(new CodigoPaisProduto(890, 890, "Índia"));
                Cod.Add(new CodigoPaisProduto(893, 893, "Vietnam"));
                Cod.Add(new CodigoPaisProduto(899, 899, "Indonésia"));
                Cod.Add(new CodigoPaisProduto(90, 91, "Áustria"));
                Cod.Add(new CodigoPaisProduto(93, 93, "Austrália"));
                Cod.Add(new CodigoPaisProduto(94, 94, "Nova Zelândia"));
                Cod.Add(new CodigoPaisProduto(955, 955, "Malaysia"));
                Cod.Add(new CodigoPaisProduto(977, 977, "Número de série internacional normalizado para periódicos(ISSN)"));
                Cod.Add(new CodigoPaisProduto(978, 978, "Numeração Padrão Internacional de Livros(ISBN)"));
                Cod.Add(new CodigoPaisProduto(979, 979, "Número Internacional de Música Padrão(ISMN)"));
                Cod.Add(new CodigoPaisProduto(980, 980, "Recibos de reembolso"));
                Cod.Add(new CodigoPaisProduto(981, 982, "Cupões de moeda comum"));
                Cod.Add(new CodigoPaisProduto(99, 99, "Cupões"));
                return Cod.OrderBy(o => o.MinCod).OrderBy(o => o.MaxCod).ToList();
            }
        }
        private List<CodigoPaisProduto> CODIGOS_SELETOR = null;

        public FGR_GeradorCodigoProduto(FCA_Produtos _FORM_PRODUTO, string _CODIGOPRODUTO)
        {
            InitializeComponent();
            FORM_PRODUTO = _FORM_PRODUTO;
            CODIGO_PRODUTO = _CODIGOPRODUTO;
            CODIGOS_SELETOR = CODIGOS;

            ovCMB_Codigos.DataSource = CODIGOS_SELETOR;
            ovCMB_Codigos.SelectedItem = CODIGOS_SELETOR.Where(o => o.MinCod == 789 && o.MaxCod == 789).FirstOrDefault();
            ovCMB_Codigos.DisplayMember = "Format";

            ovTXT_CodigoPais.Text = CODIGOS_SELETOR.Where(o => o.MinCod == 789 && o.MaxCod == 789).FirstOrDefault().MinCod.ToString();
            ovTXT_CodigoProduto.Text = CODIGO_PRODUTO;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovCMB_Codigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ovTXT_CodigoPais.Text = (ovCMB_Codigos.SelectedItem as CodigoPaisProduto).MinCod.ToString();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                FORM_PRODUTO.ovTXT_Identificacao_EAN.Text = string.Format("{0}{1}{2}{3}", ovTXT_CodigoPais.Text, ovTXT_CodigoFabrica.Text, ovTXT_CodigoProduto.Text, ovTXT_DigitoChecksum.Text);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message);
            }
        }

        private void CreateEan13()
        {
            ean13 = new Ean13();
            ean13.CountryCode = ovTXT_CodigoPais.Text;
            ean13.ManufacturerCode = ovTXT_CodigoFabrica.Text;
            ean13.ProductCode = ovTXT_CodigoProduto.Text;
            if (ovTXT_DigitoChecksum.Text.Length > 0)
                ean13.ChecksumDigit = ovTXT_DigitoChecksum.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GerarCodigoDeBarras();
        }
        public void GerarCodigoDeBarras()
        {

            try
            {
                g = picBarcode.CreateGraphics();
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));

                CreateEan13();
                ean13.Scale = 1.2f;
                ean13.DrawEan13Barcode(g, new Point(0, 0));
                ovTXT_DigitoChecksum.Text = ean13.ChecksumDigit;
                g.Dispose();

                Bitmap bmp = ean13.CreateBitmap();
                this.picBarcode.Image = bmp;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message);
            }
        }
        public string CodigoDeBarras
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", ovTXT_CodigoPais.Text, ovTXT_CodigoFabrica.Text, ovTXT_CodigoProduto.Text, ovTXT_DigitoChecksum.Text);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {

                MessageBox.Show(this, Ex.Message);
            }
        }

        private void FGR_GeradorCodigoProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
