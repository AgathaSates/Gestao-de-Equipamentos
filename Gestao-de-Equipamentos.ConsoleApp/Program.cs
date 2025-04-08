using Gestao_de_Equipamentos.ConsoleApp.Compartilhado;
using Gestao_de_Equipamentos.ConsoleApp.ModuloChamado;
using Gestao_de_Equipamentos.ConsoleApp.ModuloEquipamento;
using Gestao_de_Equipamentos.ConsoleApp.ModuloFabricante;

namespace Gestao_de_Equipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaFabricante telaFabricante = new TelaFabricante();

            RepositorioFabricante repositoriofabricante = telaFabricante.repositorioFabricante;
            TelaEquipamento telaEquipamento = new TelaEquipamento(repositoriofabricante);

            RepositorioEquipamento repositorioEquipamento = telaEquipamento.repositorioEquipamento;
            TelaChamado telaChamado = new TelaChamado(repositorioEquipamento);



            while (true)
            {
                TelaMenu.ApresentarMenu();
                string opcaoescolhida = Console.ReadLine()!;
                switch (opcaoescolhida)
                {
                    case "1": MenuEquipamentos(telaEquipamento); break;

                    case "2": MenuChamados(telaChamado); break;

                    case "3": MenuFabricante(telaFabricante); break;

                }
            }
        }

        private static void MenuFabricante(TelaFabricante telaFabricante)
        {
            string opcaoEscolhida = telaFabricante.ApresentarMenu();
            switch(opcaoEscolhida)
            {
                case "1": telaFabricante.CadastrarFabricante(); break;

                case "2": telaFabricante.EditarFabricante(); break;

                case "3": telaFabricante.ExcluirFabricante(); break;

                case "4": telaFabricante.VisualizarFabricantes(true); break;
                
                default: break;
            }
        }

        public static void MenuChamados(TelaChamado telaChamado)
        {
            string opcaoEscolhida = telaChamado.ApresentarMenu();
            switch (opcaoEscolhida)
            {
                case "1": telaChamado.CadastrarChamado(); break;

                case "2": telaChamado.EditarChamado(); break;

                case "3": telaChamado.ExcluirChamado(); break;

                case "4": telaChamado.VisualizarChamados(true); break;

                default: break;
            }
        }

        public static void MenuEquipamentos(TelaEquipamento telaEquipamento)
        {
            string opcaoEscolhida = telaEquipamento.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case "1": telaEquipamento.CadastrarEquipamento(); break;

                case "2": telaEquipamento.EditarEquipamento(); break;

                case "3": telaEquipamento.ExcluirEquipamento(); break;

                case "4": telaEquipamento.VisualizarEquipamentos(true);break;

                default: break;
            }
        }
    }
}
