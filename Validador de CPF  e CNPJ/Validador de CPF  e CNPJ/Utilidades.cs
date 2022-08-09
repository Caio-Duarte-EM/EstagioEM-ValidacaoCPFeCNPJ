namespace Validador_de_CPF__e_CNPJ;
public abstract class Utilidades
{
    public static bool ValorCpfEhValido(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            return false;
        }

        if (cpf.Length != 11)
        {
            return false;
        }

        foreach (char c in cpf)
        {
            if (!char.IsNumber(c))
            {
                return false;
            }
        }

        if (cpf.Equals("00000000000") ||
        cpf.Equals("11111111111") ||
        cpf.Equals("22222222222") ||
        cpf.Equals("33333333333") ||
        cpf.Equals("44444444444") ||
        cpf.Equals("55555555555") ||
        cpf.Equals("66666666666") ||
        cpf.Equals("77777777777") ||
        cpf.Equals("88888888888") ||
        cpf.Equals("99999999999"))
        {
            return false;
        }

        int somaDigitos = 0;
        int multiplicacaoDigitos;
        for (int i = 0; i < 9; i++)
        {
            multiplicacaoDigitos = int.Parse(cpf[i].ToString()) * (i + 1);
            somaDigitos += multiplicacaoDigitos;
        }

        int primeiroDigitoVerificador = somaDigitos % 11;
        if (primeiroDigitoVerificador == 10)
        {
            primeiroDigitoVerificador = 0;
        }
        if (primeiroDigitoVerificador != int.Parse(cpf[9].ToString()))
        {
            return false;
        }

        somaDigitos = 0;
        for (int i = 0; i < 10; i++)
        {
            multiplicacaoDigitos = int.Parse(cpf[i].ToString()) * (i);
            somaDigitos += multiplicacaoDigitos;
        }

        int segundoDigitoVerificador = somaDigitos % 11;
        if (segundoDigitoVerificador == 10)
        {
            segundoDigitoVerificador = 0;
        }
        if (segundoDigitoVerificador != int.Parse(cpf[10].ToString()))
        {
            return false;
        }

        return true;
    }

    public static string FormateCpf(string cpf)
    {
        return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
    }

    public static bool CnpjEhValido(string cnpj)
    {
        int[] multiplicadores = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            return false;
        }

        if (cnpj.Length != 14)
        {
            return false;
        }

        foreach (char c in cnpj)
        {
            if (!char.IsNumber(c))
            {
                return false;
            }
        }

        int somaDigitos = 0;
        int multiplicacaoDigitos;
        for (int i = 0; i < 12; i++)
        {
            multiplicacaoDigitos = int.Parse(cnpj[i].ToString()) * multiplicadores[i + 1];
            somaDigitos += multiplicacaoDigitos;
        }

        int primeiroDigitoVerificador = somaDigitos % 11;
        if (primeiroDigitoVerificador < 2)
        {
            primeiroDigitoVerificador = 0;
        }
        else
        {
            primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;
        }
        if (primeiroDigitoVerificador != int.Parse(cnpj[12].ToString()))
        {
            return false;
        }

        somaDigitos = 0;
        for (int i = 0; i < 13; i++)
        {
            multiplicacaoDigitos = int.Parse(cnpj[i].ToString()) * multiplicadores[i];
            somaDigitos += multiplicacaoDigitos;
        }

        int segundoDigitoVerificador = somaDigitos % 11;
        if (segundoDigitoVerificador < 2)
        {
            segundoDigitoVerificador = 0;
        }
        else
        {
            segundoDigitoVerificador = 11 - segundoDigitoVerificador;
        }
        if (segundoDigitoVerificador != int.Parse(cnpj[13].ToString()))
        {
            return false;
        }

        return true;
    }

    public static string FormateCnpj(string cnpj)
    {
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }
}