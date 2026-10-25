using System.Text.Json;

namespace NucleAR.ConsoleApp
{
    public class RepositorioCompeticao
    {
        private readonly string _caminhoArquivo = "competicoes.json";
        private List<Competicao> _competicoes = new();

        public RepositorioCompeticao()
        {
            CarregarDoArquivo();
        }

        public void CarregarDoArquivo()
        {
            try
            {
                if (File.Exists(_caminhoArquivo))
                {
                    string json = File.ReadAllText(_caminhoArquivo);
                    _competicoes = JsonSerializer.Deserialize<List<Competicao>>(json) ?? new();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Aviso] Erro ao carregar dados do arquivo: {ex.Message}");
                _competicoes = new();
            }
        }

        public void SalvarNoArquivo()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(_competicoes, options);
                File.WriteAllText(_caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Erro] Não foi possível salvar os dados: {ex.Message}");
            }
        }

        public void Adicionar(Competicao competicao)
        {
            competicao.Id = _competicoes.Count > 0 ? _competicoes.Max(c => c.Id) + 1 : 1;
            _competicoes.Add(competicao);
            SalvarNoArquivo();
        }

        public List<Competicao> ListarTodos()
        {
            return _competicoes;
        }

        public List<Competicao> BuscarPorCriterio(string criterio)
        {
            return _competicoes.Where(c =>
                c.Nome.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                c.Categoria.Contains(criterio, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}