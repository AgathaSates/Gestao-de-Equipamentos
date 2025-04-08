namespace Gestao_de_Equipamentos.ConsoleApp.ModuloFabricante
{
    class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;

        public TelaFabricante()
        {
            repositorioFabricante = new RepositorioFabricante();
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Edição de Fabricante");
            Console.WriteLine("3 - Exclusão de Fabricante");
            Console.WriteLine("4 - Visualização de Fabricantes");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Digite um opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            return opcaoEscolhida;
        }

        public void CadastrarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("       Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("      Cadastrando Fabricante...");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();

            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            repositorioFabricante.CadastrarFabricante(novoFabricante);

            Console.Write("pressione enter para continuar");
            Console.ReadLine();
        }

        public void EditarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("       Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("      Editando Fabricante...");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja editar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            Fabricante fabricanteEditado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);
            if (fabricanteEditado == null)
                Console.WriteLine("Fabricante não encontrado!");
            else
            {
                Console.Write("Digite o novo nome do fabricante: ");
                string nome = Console.ReadLine()!;

                Console.Write("Digite o novo email do fabricante: ");
                string email = Console.ReadLine()!;

                Console.Write("Digite o novo telefone do fabricante: ");
                string telefone = Console.ReadLine()!;

                Fabricante novoFabricante = new Fabricante(nome, email, telefone);

                repositorioFabricante.EditarFabricante(idFabricante, novoFabricante);

                Console.WriteLine("Fabricante editado com sucesso!");

                Console.Write("pressione enter para continuar");
                Console.ReadLine();
            }
        }

        public void ExcluirFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("       Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("      Excluindo Fabricante...");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine());

            bool fabricanteExcluido = repositorioFabricante.ExcluirFabricante(idFabricante);
            if (fabricanteExcluido)
                Console.WriteLine("Fabricante excluído com sucesso!");
            else
                Console.WriteLine("Fabricante não encontrado!");

            Console.Write("pressione enter para continuar");
            Console.ReadLine();
        }

        public void VisualizarFabricantes(bool ExibirTitulo)
        {
            if (ExibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("       Gestão de Fabricantes");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("      Visualizando Fabricantes...");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
            }
            Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -20} | {3, -15} |",
            "Id", "Nome", "E-mail", "Telefone");
       
            Fabricante[] fabricantescadastrados = repositorioFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantescadastrados.Length; i++)
            {
                if (fabricantescadastrados[i] == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -20} | {3, -15} |",
                    fabricantescadastrados[i].id,
                    fabricantescadastrados[i].nome,
                    fabricantescadastrados[i].email,
                    fabricantescadastrados[i].telefone);
            }


            Console.Write("pressione enter para continuar");
            Console.ReadLine();
        }
    }
}
