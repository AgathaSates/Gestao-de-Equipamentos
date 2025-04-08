
using Gestao_de_Equipamentos.ConsoleApp.Compartilhado;

namespace Gestao_de_Equipamentos.ConsoleApp.ModuloEquipamento;

class RepositorioEquipamento
{
    public Equipamento[] equipamentos = new Equipamento[100];
    public int contadorEquipamentos = 0;

    public void CadastrarEquipamento(Equipamento novoEquipamento)
    {
        novoEquipamento.iD = GeradorIds.GerarIdEquipamento();
        equipamentos[contadorEquipamentos++] = novoEquipamento;
        Console.WriteLine("Equipamento registrado!");
    }

    public bool EditarEquipamento(int idEquipamento, Equipamento equipamentoEditado)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null) continue;

            else if (equipamentos[i].iD == idEquipamento)
            {
                equipamentos[i].nome = equipamentoEditado.nome;
                equipamentos[i].fabricante = equipamentoEditado.fabricante;
                equipamentos[i].precoAquisicao = equipamentoEditado.precoAquisicao;
                equipamentos[i].dataFabricacao = equipamentoEditado.dataFabricacao;

                return true;
            }
        }

        return false;
    }

    public bool ExcluirEquipamento(int idEquipamento)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null) continue;

            else if (equipamentos[i].iD == idEquipamento)
            {
                equipamentos[i] = null;

                return true;
            }
        }

        return false;
    }

    public Equipamento[] SelecionarEquipamentos()
    {
        return equipamentos;
    }

    public Equipamento SelecionarEquipamentoPorId(int idEquipamento)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            else if (e.iD == idEquipamento)
                return e;
        }

        return null;
    }
}