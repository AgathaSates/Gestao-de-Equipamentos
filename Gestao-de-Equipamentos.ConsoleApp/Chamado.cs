namespace Gestao_de_Equipamentos.ConsoleApp;
class Chamado
{
    public int iD;
    public string titulo;
    public string descricao;
    public Equipamento equipamento;
    public DateTime dataAbertura;

    public Chamado(string titulo, string descricao, Equipamento equipamento)
    {
        this.titulo = titulo;
        this.descricao = descricao;
        this.equipamento = equipamento;
        this.dataAbertura = DateTime.Now;
    }
}
