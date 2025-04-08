using Gestao_de_Equipamentos.ConsoleApp.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ConsoleApp.ModuloChamado;
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
        dataAbertura = DateTime.Now;
    }

    public int ObterTempoDecorrido()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(dataAbertura);

        return diferencaTempo.Days;
    }
}
