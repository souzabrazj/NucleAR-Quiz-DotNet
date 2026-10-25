using NucleAR.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioCompeticao repositorio = new RepositorioCompeticao();
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("       NUCLEAR QUIZ - MÓDULO ADMINISTRATIVO       ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Cadastrar Nova Competição");
            Console.WriteLine("2. Listar Todas as Competições");
            Console.WriteLine("3. Buscar Competição (por Nome ou Categoria)");
            Console.WriteLine("4. Sair");
            Console.Write("\nEscolha uma opção: ");

            string? opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        CadastrarCompeticao(repositorio);
                        break;
                    case "2":
                        ListarCompeticoes(repositorio);
                        break;
                    case "3":
                        BuscarCompeticao(repositorio);
                        break;
                    case "4":
                        executando = false;
                        Console.WriteLine("\nEncerrando a aplicação NucleAR. Até logo!");
                        break;
                    default:
                        Console.WriteLine("\n[Erro] Opção inválida! Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Erro Inesperado]: {ex.Message}");
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
            }
        }
    }

    static void CadastrarCompeticao(RepositorioCompeticao repositorio)
    {
        Console.Clear();
        Console.WriteLine("--- CADASTRAR NOVA COMPETIÇÃO ---");

        Competicao c = new Competicao();

        Console.Write("Nome da Competição: ");
        c.Nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Categoria Temática (Medicina, Agricultura, Indústria): ");
        c.Categoria = Console.ReadLine() ?? string.Empty;

        Console.Write("Quantidade de Questões (4 a 10): ");
        if (int.TryParse(Console.ReadLine(), out int qtd))
        {
            c.QuantidadeQuestoes = qtd;
        }

        Console.Write("Premiação: ");
        c.Premiacao = Console.ReadLine() ?? string.Empty;

        Console.Write("Data e Hora de Encerramento (formato AAAA-MM-DD HH:MM): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
        {
            c.DataEncerramento = data;
        }

        if (c.Validar(out string erro))
        {
            repositorio.Adicionar(c);
            Console.WriteLine("\n[Sucesso] Competição cadastrada e salva com sucesso!");
        }
        else
        {
            Console.WriteLine($"\n[Validação Falhou]: {erro}");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void ListarCompeticoes(RepositorioCompeticao repositorio)
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE COMPETIÇÕES CADASTRADAS ---");
        var lista = repositorio.ListarTodos();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma competição cadastrada no momento.");
        }
        else
        {
            foreach (var c in lista)
            {
                Console.WriteLine($"\nID: {c.Id} | Nome: {c.Nome}");
                Console.WriteLine($"Categoria: {c.Categoria} | Questões: {c.QuantidadeQuestoes}");
                Console.WriteLine($"Premiação: {c.Premiacao} | Encerramento: {c.DataEncerramento:dd/MM/yyyy HH:mm}");
                Console.WriteLine(new string('-', 40));
            }
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void BuscarCompeticao(RepositorioCompeticao repositorio)
    {
        Console.Clear();
        Console.WriteLine("--- BUSCAR COMPETIÇÃO ---");
        Console.Write("Digite o termo de busca (Nome ou Categoria): ");
        string termo = Console.ReadLine() ?? string.Empty;

        var resultados = repositorio.BuscarPorCriterio(termo);

        Console.WriteLine($"\nEncontrados {resultados.Count} resultado(s):");
        foreach (var c in resultados)
        {
            Console.WriteLine($"\n[ID: {c.Id}] {c.Nome} - Categoria: {c.Categoria} (Prêmio: {c.Premiacao})");
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}