namespace Validador_de_CPF_e_CNPJ;
public readonly struct Cpf 
{
    public readonly string Valor;
    private Cpf(string valorValido)
    {
        Valor = Utilidades.ValorCpfEhValido(valorValido) ? Utilidades.FormateCpf(valorValido) : "123.456.789-09";
    }

    public static implicit operator string(Cpf cpf) => cpf.Valor;
    public static explicit operator Cpf(string v) => new(v);
}