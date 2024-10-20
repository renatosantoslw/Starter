using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

public class ClsExtenso
{
    /// <summary>
    /// Função para escrever por extenso os valores em Real (em C# - suporta até R$ 9.999.999.999,99) 
    /// Rotina Criada para ler um número e transformá-lo em extenso 
    /// Limite máximo de 9 Bilhões (9.999.999.999,99).
    /// Não aceita números negativos.
    /// </summary>
    /// <param name="pdbl_Valor">Valor para converter em extenso. Limite máximo de 9 Bilhões (9.999.999.999,99).</param>
    /// <returns>String do valor por Extenso</returns>
    public static string Extenso_Valor(decimal pdbl_Valor)
    {
        //Verificar se foi informado um dado indevido
        if (pdbl_Valor == 0 || pdbl_Valor <= 0)
        {
            throw new Exception("Valor não suportado pela Função. Verificar se há valor negativo ou nada foi informado");
        }
        if (pdbl_Valor > (decimal)9999999999.99)
        {
            throw new Exception("Valor não suportado pela Função. Verificar se o Valor está acima de 9999999999.99");
        }

        return TraduzValor(pdbl_Valor);
    }

    public static bool TryExtensoValor(decimal pdbl_Valor, out String Retorno) 
    {
        Retorno = String.Empty;

        if (pdbl_Valor == 0 || pdbl_Valor <= 0)
        {
            return false;
        }
        if (pdbl_Valor > (decimal)9999999999.99)
        {
            return false;
        }

        Retorno = TraduzValor(pdbl_Valor);
        return true;
    }


    private static string TraduzValor(decimal pdbl_Valor)
    {
        string strValorExtenso = ""; //Variável que irá armazenar o valor por extenso do número informado
        string strNumero = ""; //Irá armazenar o número para exibir por extenso
        string strCentena = "";
        string strDezena = "";
        string strDezCentavo = "";

        decimal dblCentavos = 0;
        decimal dblValorInteiro = 0;
        int intContador = 0;
        bool bln_Bilhao = false;
        bool bln_Milhao = false;
        bool bln_Mil = false;
        bool bln_Unidade = false;

        //Gerar Extenso Centavos
        pdbl_Valor = (Decimal.Round(pdbl_Valor, 2));
        dblCentavos = pdbl_Valor - (Int64)pdbl_Valor;

        //Gerar Extenso parte Inteira
        dblValorInteiro = (Int64)pdbl_Valor;
        if (dblValorInteiro > 0)
        {
            if (dblValorInteiro > 999)
            {
                bln_Mil = true;
            }
            if (dblValorInteiro > 999999)
            {
                bln_Milhao = true;
                bln_Mil = false;
            }
            if (dblValorInteiro > 999999999)
            {
                bln_Mil = false;
                bln_Milhao = false;
                bln_Bilhao = true;
            }

            for (int i = (dblValorInteiro.ToString().Trim().Length) - 1; i >= 0; i--)
            {
                // strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) + 1, 1);
                strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 1);
                switch (i)
                { /*******/
                    case 9: /*Bilhão*
/*******/
                        {
                            strValorExtenso = fcn_Numero_Unidade(strNumero) + ((int.Parse(strNumero) > 1) ? " Bilhoes e" : " Bilhao e");
                            bln_Bilhao = true;
                            break;
                        }
                    case 8: /********/
                    case 5: //Centena*
                    case 2: /********/
                        {
                            if (int.Parse(strNumero) > 0)
                            {
                                strCentena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 3);

                                if (int.Parse(strCentena) > 100 && int.Parse(strCentena) < 200)
                                {
                                    strValorExtenso = strValorExtenso + " Cento e ";
                                }
                                else
                                {
                                    strValorExtenso = strValorExtenso + " " + fcn_Numero_Centena(strNumero);
                                }
                                if (intContador == 8)
                                {
                                    bln_Milhao = true;
                                }
                                else if (intContador == 5)
                                {
                                    bln_Mil = true;
                                }
                            }
                            break;
                        }
                    case 7: /*****************/
                    case 4: //Dezena de Milhão*
                    case 1: /*****************/
                        {
                            if (int.Parse(strNumero) > 0)
                            {
                                strDezena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 2);//

                                if (int.Parse(strDezena) > 10 && int.Parse(strDezena) < 20)
                                {
                                    strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ")
                                    + fcn_Numero_Dezena0(Right(strDezena, 1));//corrigido

                                    bln_Unidade = true;
                                }
                                else
                                {
                                    strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? " e " : " ")
                                    + fcn_Numero_Dezena1(Left(strDezena, 1));//corrigido

                                    bln_Unidade = false;
                                }
                                if (intContador == 7)
                                {
                                    bln_Milhao = true;
                                }
                                else if (intContador == 4)
                                {
                                    bln_Mil = true;
                                }
                            }
                            break;
                        }
                    case 6: /******************/
                    case 3: //Unidade de Milhão*
                    case 0: /******************/
                        {
                            if (int.Parse(strNumero) > 0 && !bln_Unidade)
                            {
                                if ((Right(strValorExtenso, 5).Trim()) == "entos"
                                || (Right(strValorExtenso, 3).Trim()) == "nte"
                                || (Right(strValorExtenso, 3).Trim()) == "nta")
                                {
                                    strValorExtenso = strValorExtenso + " e ";
                                }
                                else
                                {
                                    strValorExtenso = strValorExtenso + " ";
                                }
                                strValorExtenso = strValorExtenso + fcn_Numero_Unidade(strNumero);
                            }
                            if (i == 6)
                            {
                                if (bln_Milhao || int.Parse(strNumero) > 0)
                                {
                                    strValorExtenso = strValorExtenso + ((int.Parse(strNumero) == 1) && !bln_Unidade ? " Milhao" : " Milhoes");
                                    strValorExtenso = strValorExtenso + ((int.Parse(strNumero) > 1000000) ? " " : " e");
                                    bln_Milhao = true;
                                }
                            }
                            if (i == 3)
                            {
                                if (bln_Mil || int.Parse(strNumero) > 0)
                                {
                                    strValorExtenso = strValorExtenso + " Mil";
                                    strValorExtenso = strValorExtenso + ((int.Parse(strNumero) > 1000) ? " " : " e");
                                    bln_Mil = true;
                                }
                            }
                            if (i == 0)
                            {
                                if ((bln_Bilhao && !bln_Milhao && !bln_Mil
                                && Right((dblValorInteiro.ToString().Trim()), 3) == "0")
                                || (!bln_Bilhao && bln_Milhao && !bln_Mil
                                && Right((dblValorInteiro.ToString().Trim()), 3) == "0"))
                                {
                                    strValorExtenso = strValorExtenso + " e ";
                                }
                                strValorExtenso = strValorExtenso + ((Int64.Parse(dblValorInteiro.ToString())) > 1 ? " Reais" : " Real");
                            }
                            bln_Unidade = false;
                            break;
                        }
                }
            }//
        }
        if (dblCentavos > 0)
        {

            if (dblCentavos > 0 && dblCentavos < 0.1M)
            {
                strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                strValorExtenso = strValorExtenso + ((dblCentavos > 0) ? " e " : " ")
                + fcn_Numero_Unidade(strNumero) + ((dblCentavos > 0.01M) ? " Centavos" : " Centavo");
            }
            else if (dblCentavos > 0.1M && dblCentavos < 0.2M)
            {
                strNumero = Right(((Decimal.Round(dblCentavos, 2) - (decimal)0.1).ToString().Trim()), 1);
                strValorExtenso = strValorExtenso + ((dblCentavos > 0) ? " " : " e ")
                + fcn_Numero_Dezena0(strNumero) + " Centavos ";
            }
            else
            {
                strNumero = Right(dblCentavos.ToString("0.00").Trim(), 2);
                strDezCentavo = Mid(dblCentavos.ToString("0.00").Trim(), 2, 1);

                strValorExtenso = strValorExtenso + ((int.Parse(strNumero) > 0) ? " e " : " ");
                strValorExtenso = strValorExtenso + fcn_Numero_Dezena1(Left(strDezCentavo, 1));

                if ((dblCentavos.ToString().Trim().Length) > 2)
                {
                    strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString("0.00").Trim(), 1);
                    if (int.Parse(strNumero) > 0)
                    {
                        if (dblValorInteiro <= 0)
                        {
                            if (Mid(strValorExtenso.Trim(), strValorExtenso.Trim().Length - 2, 1) == "e")
                            {
                                strValorExtenso = strValorExtenso + " e " + fcn_Numero_Unidade(strNumero);
                            }
                            else
                            {
                                strValorExtenso = strValorExtenso + " e " + fcn_Numero_Unidade(strNumero);
                            }
                        }
                        else
                        {
                            strValorExtenso = strValorExtenso + " e " + fcn_Numero_Unidade(strNumero);
                        }
                    }
                }
                strValorExtenso = strValorExtenso + " Centavos ";
            }
        }
        if (dblValorInteiro < 1) strValorExtenso = Mid(strValorExtenso.Trim(), 2, strValorExtenso.Trim().Length - 2);

        return strValorExtenso.Trim();
    }

    private static string fcn_Numero_Dezena0(string pstrDezena0)
    {
        //Vetor que irá conter o número por extenso
        ArrayList array_Dezena0 = new ArrayList();

        array_Dezena0.Add("Onze");
        array_Dezena0.Add("Doze");
        array_Dezena0.Add("Treze");
        array_Dezena0.Add("Quatorze");
        array_Dezena0.Add("Quinze");
        array_Dezena0.Add("Dezesseis");
        array_Dezena0.Add("Dezessete");
        array_Dezena0.Add("Dezoito");
        array_Dezena0.Add("Dezenove");

        return array_Dezena0[((int.Parse(pstrDezena0)) - 1)].ToString();
    }
    private static string fcn_Numero_Dezena1(string pstrDezena1)
    {
        //Vetor que irá conter o número por extenso
        ArrayList array_Dezena1 = new ArrayList();

        array_Dezena1.Add("Dez");
        array_Dezena1.Add("Vinte");
        array_Dezena1.Add("Trinta");
        array_Dezena1.Add("Quarenta");
        array_Dezena1.Add("Cinquenta");
        array_Dezena1.Add("Sessenta");
        array_Dezena1.Add("Setenta");
        array_Dezena1.Add("Oitenta");
        array_Dezena1.Add("Noventa");

        return array_Dezena1[Int16.Parse(pstrDezena1) - 1].ToString();
    }

    private static string fcn_Numero_Centena(string pstrCentena)
    {
        //Vetor que irá conter o número por extenso
        ArrayList array_Centena = new ArrayList();

        array_Centena.Add("Cem");
        array_Centena.Add("Duzentos");
        array_Centena.Add("Trezentos");
        array_Centena.Add("Quatrocentos");
        array_Centena.Add("Quinhentos");
        array_Centena.Add("Seiscentos");
        array_Centena.Add("Setecentos");
        array_Centena.Add("Oitocentos");
        array_Centena.Add("Novecentos");

        return array_Centena[((int.Parse(pstrCentena)) - 1)].ToString();
    }
    private static string fcn_Numero_Unidade(string pstrUnidade)
    {
        //Vetor que irá conter o número por extenso
        ArrayList array_Unidade = new ArrayList();

        array_Unidade.Add("Um");
        array_Unidade.Add("Dois");
        array_Unidade.Add("Tres");
        array_Unidade.Add("Quatro");
        array_Unidade.Add("Cinco");
        array_Unidade.Add("Seis");
        array_Unidade.Add("Sete");
        array_Unidade.Add("Oito");
        array_Unidade.Add("Nove");

        return array_Unidade[(int.Parse(pstrUnidade) - 1)].ToString();
    }

    #region Métodos de Compatibilazação com VB 6 .........Left() Right() Mid()
    public static string Left(string param, int length)
    {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        if (param == "")
            return "";
        string result = param.Substring(0, length);
        //return the result of the operation
        return result;
    }
    public static string Right(string param, int length)
    {
        //start at the index based on the lenght of the sting minus
        //the specified lenght and assign it a variable
        if (param == "")
            return "";
        string result = param.Substring(param.Length - length, length);
        //return the result of the operation
        return result;
    }

    public static string Mid(string param, int startIndex, int length)
    {
        //start at the specified index in the string ang get N number of
        //characters depending on the lenght and assign it to a variable
        string result = param.Substring(startIndex, length);
        //return the result of the operation
        return result;
    }

    public static string Mid(string param, int startIndex)
    {
        //start at the specified index and return all characters after it
        //and assign it to a variable
        string result = param.Substring(startIndex);
        //return the result of the operation
        return result;
    }
    #endregion
}
