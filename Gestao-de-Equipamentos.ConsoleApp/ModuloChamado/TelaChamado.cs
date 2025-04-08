using Gestao_de_Equipamentos.ConsoleApp.Compartilhado;
using Gestao_de_Equipamentos.ConsoleApp.ModuloEquipamento;

namespace Gestao_de_Equipamentos.ConsoleApp.ModuloChamado;

class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public TelaChamado(RepositorioEquipamento repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        repositorioChamado = new RepositorioChamado();
    }

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

    public void CadastrarChamado()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("          Gestão de Chamados");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("         Cadastrando chamado...");
        Console.WriteLine("--------------------------------------------");

        Chamado novoChamado = ObterDadosChamado();
        repositorioChamado.CadastrarChamado(novoChamado);

        Console.Write("pressione enter para continuar");
        Console.ReadLine();
    }

    

    public void EditarChamado()
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

        Chamado novoChamado = ObterDadosChamado();

        bool conseguiuEditar = repositorioChamado.EditarChamado(id, novoChamado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O chamado foi editado com sucesso!");

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

        bool conseguiuExcluir = repositorioChamado.ExcluirChamado(idSelecionado);

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

        Chamado[] chamadosCadastrados = repositorioChamado.SelecionarChamados();

        for (int i = 0; i < chamadosCadastrados.Length; i++)
        {
            Chamado c = chamadosCadastrados[i];

            if (c == null)
                continue;

            string tempoDecorrido = $"{c.ObterTempoDecorrido()} dia(s)";

            Console.WriteLine(
                "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
                c.iD, c.dataAbertura.ToShortDateString(), c.titulo, c.descricao, c.equipamento.nome, tempoDecorrido
            );

            Console.Write("pressione enter para continuar");
            Console.ReadLine();
        }
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine("Visualizando Equipamentos...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento e = equipamentosCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.iD, e.nome, e.ObterNumeroSerie(), e.fabricante, e.precoAquisicao.ToString("C2"), e.dataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();
    }

    public Chamado ObterDadosChamado()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine()!.Trim();

        Console.Write("Digite o descrição do chamado: ");
        string descricao = Console.ReadLine()!.Trim();

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine()!.Trim());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }
}
