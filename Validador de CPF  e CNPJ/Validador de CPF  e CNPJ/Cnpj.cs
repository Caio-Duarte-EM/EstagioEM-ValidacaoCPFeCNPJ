namespace Validador_de_CPF_e_CNPJ;

public readonly struct Cnpj 
{
    public readonly string Valor;
    private Cnpj(string valorValido)
    {
        Valor = CnpjEhValido(valorValido) ? FormateCnpj(valorValido) : "00.000.000/0001-00";
    }

    public static implicit operator string(Cnpj cnpj) => cnpj.Valor;
    public static explicit operator Cnpj(string v) => new(v);

    static bool CnpjEhValido(string cnpj)
    {
        int[] multiplicadores = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        if (string.IsNullOrWhiteSpace(cnpj))
        {
            return false;
        }

        if (cnpj.Contains(' '))
        {
            return false;
        }

        if (cnpj.Length != 14)
        {
            return false;
        }

        bool cnpjEhNumerico = long.TryParse(cnpj, out _);
        if (cnpjEhNumerico == false)
        {
            return false;
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
    static string FormateCnpj(string cnpj)
    {
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }
}