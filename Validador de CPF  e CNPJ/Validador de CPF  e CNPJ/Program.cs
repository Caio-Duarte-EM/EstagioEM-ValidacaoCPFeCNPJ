using Validador_de_CPF_e_CNPJ;

Console.WriteLine("O que deseja validar? \n" +
    "(1) - CPF\n" +
    "(2) - CNPJ");
string? opcao = Console.ReadLine()?.Trim();
if (opcao == "1")
{
    Console.Write("Digite um CPF: ");
    string valor = Console.ReadLine()?.Trim().Replace(".", "").Replace("-", "") ?? "";
    Cpf cpf = (Cpf)valor;
    if(cpf == "000.000.000-00")
    {
        Console.Write("CPF inválido\n" +
            "Valor Padrão: ");
    }
    Console.WriteLine(cpf.Valor);
}
else if(opcao == "2")
{
    Console.Write("Digite um CNPJ: ");
    string valor = Console.ReadLine()?.Trim().Replace(".", "").Replace("-", "").Replace("/", "") ?? "";
    Cnpj cnpj = (Cnpj)valor;
    if (cnpj == "00.000.000/0001-00")
    {
        Console.Write("CNPJ inválido\n" +
            "Valor Padrão: ");
    }
    Console.WriteLine(cnpj.Valor);
}
else
{
    Console.WriteLine("Opção inválida");
}