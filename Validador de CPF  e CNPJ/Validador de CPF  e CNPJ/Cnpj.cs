namespace Validador_de_CPF_e_CNPJ;
public readonly struct Cnpj 
{
    public readonly string Valor;
    private Cnpj(string valorValido)
    {
        Valor = Utilidades.ValorCnpjEhValido(valorValido) ? Utilidades.FormateCnpj(valorValido) : "12.345.678/0001-95";
    }

    public static implicit operator string(Cnpj cnpj) => cnpj.Valor;
    public static explicit operator Cnpj(string v) => new(v);
}