﻿namespace Gestao_de_Equipamentos.ConsoleApp;

public static class TelaMenu
{
    public static void ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("    Bem vindo ao Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("1 - Acessar o menu de Equipamentos");
        Console.WriteLine("2 - Acessar o menu de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.Write("Digite uma opção: ");
    }
}
