using Gestao_de_Equipamentos.ConsoleApp.ModuloFabricante;

namespace Gestao_de_Equipamentos.ConsoleApp.ModuloEquipamento;

class Equipamento
{
    public int iD;
    public string nome;
    public Fabricante Fabricante;
    public decimal precoAquisicao;
    public DateTime dataFabricacao;

    public Equipamento(string nome, Fabricante fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        this.nome = nome;
        Fabricante = fabricante;
        this.precoAquisicao = precoAquisicao;
        this.dataFabricacao = dataFabricacao;
    }

    public string ObterNumeroSerie()
    {
        string tresPrimeirosCaracteres = nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{iD}";
    }
}
