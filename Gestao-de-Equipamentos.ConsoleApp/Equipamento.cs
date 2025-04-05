﻿namespace Gestao_de_Equipamentos.ConsoleApp;

class Equipamento
{
    public int iD;
    public string nome;
    public string fabricante;
    public decimal precoAquisicao;
    public DateTime dataFabricacao;

    public Equipamento(string nome, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        this.nome = nome;
        this.fabricante = fabricante;
        this.precoAquisicao = precoAquisicao;
        this.dataFabricacao = dataFabricacao;
    }

    public string ObterNumeroSerie()
    {
        string tresPrimeirosCaracteres = nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{iD}";
    }
}
