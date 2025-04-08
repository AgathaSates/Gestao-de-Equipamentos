namespace Gestao_de_Equipamentos.ConsoleApp.ModuloFabricante;
using Gestao_de_Equipamentos.ConsoleApp.Compartilhado;

class RepositorioFabricante
{
    Fabricante[] fabricantes = new Fabricante[100];
    int quantidadeFabricantes = 0;

    public void CadastrarFabricante(Fabricante novoFabricante)
    {
        novoFabricante.id = GeradorIds.GerarIdFabricante();
        fabricantes[quantidadeFabricantes++] = novoFabricante;
        Console.WriteLine("Fabricante registrado!");
    }
    public bool EditarFabricante(int idFabricante, Fabricante fabricanteEditado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;
            else if (fabricantes[i].id == idFabricante)
            {
                fabricantes[i].nome = fabricanteEditado.nome;
                fabricantes[i].email = fabricanteEditado.email;
                fabricantes[i].telefone = fabricanteEditado.telefone;
                return true;
            }
        }
        return false;
    }

    public bool ExcluirFabricante(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;
            else if (fabricantes[i].id == idFabricante)
            {
                fabricantes[i] = null;
                return true;
            }
        }
        return false;
    }
   
    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public Fabricante SelecionarFabricantePorId(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;
            else if (fabricantes[i].id == idFabricante)
                return fabricantes[i];
        }
        return null;
    }
}
