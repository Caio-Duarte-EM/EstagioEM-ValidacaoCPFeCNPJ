namespace Validador_de_CPF_e_CNPJ;
public readonly struct Cpf
{
    public readonly string Valor;

    private Cpf(string valorValido)
    {
        Valor = ValorCpfEhValido(valorValido) ? FormateCpf(valorValido) : "000.000.000-00";
    }

    public static implicit operator string(Cpf cpf) => cpf.Valor;
    public static explicit operator Cpf(string v) => new(v);

    static bool ValorCpfEhValido(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            return false;
        }

        if (cpf.Length != 11)
        {
            return false;
        }

        bool cpfEhNumerico = long.TryParse(cpf, out _);
        if (cpfEhNumerico == false)
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

    static string FormateCpf(string cpf)
    {
        return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
    }
}