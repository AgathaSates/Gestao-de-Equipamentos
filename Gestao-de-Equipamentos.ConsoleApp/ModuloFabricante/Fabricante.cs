namespace Gestao_de_Equipamentos.ConsoleApp.ModuloFabricante;

class Fabricante
{
    public int id;
    public string nome;
    public string email;
    public string telefone;


    public Fabricante(string nome, string email, string telefone)
    {
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
    }

    public override string ToString()
    {
        return nome;
    }
}
