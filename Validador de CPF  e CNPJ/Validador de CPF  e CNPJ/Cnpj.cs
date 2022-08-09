using Validador_de_CPF__e_CNPJ;
namespace Validador_de_CPF_e_CNPJ;
public readonly struct Cnpj : IUtilidades
{
    public readonly string Valor;
    private Cnpj(string valorValido)
    {
        Valor = IUtilidades.CnpjEhValido(valorValido) ? IUtilidades.FormateCnpj(valorValido) : "12.345.678/0001-95";
    }

    public static implicit operator string(Cnpj cnpj) => cnpj.Valor;
    public static explicit operator Cnpj(string v) => new(v);
}