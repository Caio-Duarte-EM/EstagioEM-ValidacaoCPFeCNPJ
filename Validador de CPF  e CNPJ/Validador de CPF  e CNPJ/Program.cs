using Validador_de_CPF_e_CNPJ;

Console.WriteLine("O que deseja validar? \n" +
    "(1) - CPF\n" +
    "(2) - CNPJ");
string? opcao = Console.ReadLine()?.Trim();
string valor;
if (opcao == "1")
{
    Console.Write("Digite um CPF: ");
    valor = Console.ReadLine()?.Replace(".", "").Replace("-", "").Replace(" ", "") ?? "";
    var cpf = (Cpf)valor;
    if (cpf == "123.456.789-09" && valor != "12345678909")
    {
        Console.Write("CPF inválido\n" +
            "Valor Padrão: ");
    }
    Console.WriteLine(cpf);
}
else if (opcao == "2")
{
    Console.Write("Digite um CNPJ: ");
    valor = Console.ReadLine()?.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") ?? "";
    var cnpj = (Cnpj)valor;
    if (cnpj == "12.345.678/0001-95" && valor != "12345678000195")
    {
        Console.Write("CNPJ inválido\n" +
            "Valor Padrão: ");
    }
    Console.WriteLine(cnpj);
}
else
{
    Console.WriteLine("Opção inválida");
}