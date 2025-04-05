namespace Gestao_de_Equipamentos.ConsoleApp;

class TelaChamado
{
    public Chamado[] chamados = new Chamado[100];
    public int contadorChamados = 0;

    public string ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("          Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("1 - Cadastro de chamado");
        Console.WriteLine("2 - Edição de chamado");
        Console.WriteLine("3 - Exclusão de chamado");
        Console.WriteLine("4 - Visualização de chamado");
        Console.WriteLine("--------------------------------------------");

        Console.Write("Digite um opção: ");
        string opcaoEscolhida = Console.ReadLine();

        return opcaoEscolhida;
    }

    public void CadastrarChamado(TelaEquipamento telaequipamentos)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("          Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("         Cadastrando chamado...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.Write("Digite o titulo do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o iD do equipamento que deseja abrir o chamado: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoEncontrado = EquipamentoExiste(telaequipamentos, id);

        if (equipamentoEncontrado != null)
            Console.WriteLine("Chamado cadastrado com sucesso!");

        else
            Console.WriteLine("Equipamento não encontrado.");

        Chamado novochamado = new Chamado(titulo, descricao, equipamentoEncontrado);
        novochamado.iD = GeradorIds.GerarIdChamado();

        chamados[contadorChamados++] = novochamado;

        Console.Write("pressione enter para continuar");
        Console.ReadLine();
    }

    

    public void EditarChamado(TelaEquipamento telaequipamentos)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("           Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("           Editando chamado...");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine();

        Console.Write("Digite o iD do chamado que deseja editar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Chamado chamadoEncontrado = null;

        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i].iD == id)
            {
                chamadoEncontrado = chamados[i];
                break;
            }
        }

        if (chamadoEncontrado != null)
        {
            Console.Write("Digite o novo título do chamado: ");
            string novoTitulo = Console.ReadLine();

            Console.Write("Digite a nova descrição do chamado: ");
            string novaDescricao = Console.ReadLine();

            Console.Write("Digite o iD do equipamento que deseja abrir o chamado: ");
            id = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoEncontrado = EquipamentoExiste(telaequipamentos, id);
            
            chamadoEncontrado.titulo = novoTitulo;
            chamadoEncontrado.descricao = novaDescricao;
            chamadoEncontrado.equipamento = equipamentoEncontrado;

            Console.WriteLine("Chamado editado com sucesso!");
        }

        else
            Console.WriteLine("Chamado não encontrado.");

        Console.Write("pressione enter para continuar");
        Console.ReadLine();
    }

    public void ExcluirChamado()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("          Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("         Excluindo chamado...");
        Console.WriteLine("--------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = false;

        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            else if (chamados[i].iD == idSelecionado)
            {
                chamados[i] = null;
                Console.WriteLine("Chamado excluído com sucesso!");
                conseguiuExcluir = true;
                break;
            }
        }

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão do registro...");
            return;
        }
        
        Console.Write("pressione enter para continuar");
        Console.ReadLine();
    }

    public void VisualizarChamados(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("             Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          Visualizando chamados...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine(
              "{0, -5} | {1, -15} | {2, -15} | {3, -11} | {4, -15} | ",
              "ID", "Título", "Equipamento", "Data de abertura", "Dias do chamado aberto"
          );
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -11} | {4, -15:F0} | ",
                chamados[i].iD,
                chamados[i].titulo,
                chamados[i].equipamento.nome,
                chamados[i].dataAbertura.ToString("dd/MM/yyyy"),
                (DateTime.Now - chamados[i].dataAbertura).TotalDays
            );
        }
        Console.Write("pressione enter para continuar");
        Console.ReadLine();
    }

    public static Equipamento EquipamentoExiste(TelaEquipamento telaequipamentos, int id)
    {
        Equipamento equipamentoEncontrado = null;

        foreach (Equipamento equipamento in telaequipamentos.equipamentos)
        {
            if (equipamento != null && equipamento.iD == id)
            {
                equipamentoEncontrado = equipamento;
                break;
            }
        }

        return equipamentoEncontrado;
    }
}
