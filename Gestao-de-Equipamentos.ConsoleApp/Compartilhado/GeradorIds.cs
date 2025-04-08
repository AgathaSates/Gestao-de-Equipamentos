namespace Gestao_de_Equipamentos.ConsoleApp.Compartilhado;

class GeradorIds
{
    public static int idEquipamentos = 0;
    public static int idChamados = 0;
    public static int idFabricantes = 0;
    public static int GerarIdEquipamento()
    {
        idEquipamentos++;

        return idEquipamentos;
    }
    
    public static int GerarIdChamado()
    {
        idChamados++;

        return idChamados;
    }

    public static int GerarIdFabricante()
    {
      idFabricantes++;

       return idFabricantes;
    }
}
