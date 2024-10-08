using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Livro> Livros = [];

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("Gerenciamento de Livros - Biblioteca");
            Console.WriteLine("1. Cadastrar Livro");
            Console.WriteLine("2. Exibir Livros");
            Console.WriteLine("3. Buscar Livro por Título ou Autor");
            Console.WriteLine("4. Excluir Livro");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarLivro();
                    break;
                case 2:
                    ExibirLivros();
                    break;
                case 3:
                    BuscarLivro();
                    break;
                case 4:
                    ExcluirLivro();
                    break;
                case 5:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 5);
    }

    static void CadastrarLivro()
    {
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();
        Console.Write("Digite o número de páginas: ");
        int numeroPaginas = int.Parse(Console.ReadLine());
        Console.Write("Digite o ano de publicação: ");
        int anoPublicacao = int.Parse(Console.ReadLine());

        Livro novoLivro = new()
        {
            Titulo = titulo,
            Autor = autor,
            NumeroPaginas= numeroPaginas,
            AnoPublicacao= anoPublicacao
        };

        Livros.Add(novoLivro);
        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    static void ExibirLivros()
    {
        if (Livros.Count == 0)
        {
            Console.WriteLine("Nenhum livro cadastrado.");
        }
        else
        {
            Console.WriteLine("Livros cadastrados:");
            foreach (Livro livro in Livros)
            {
                Console.WriteLine(livro);
            }
        }
    }

    static void BuscarLivro()
    {
        Console.Write("Digite o título ou autor para buscar: ");
        string busca = Console.ReadLine().ToLower();

        var livrosEncontrados = Livros.Where(l => l.Titulo
        .Contains(busca, StringComparison.CurrentCultureIgnoreCase) || l.Autor
        .Contains(busca, StringComparison.CurrentCultureIgnoreCase)).ToList();

        if (livrosEncontrados.Count == 0)
        {
            Console.WriteLine("Nenhum livro encontrado.");
        }
        else
        {
            Console.WriteLine("Livros encontrados:");
            foreach (Livro livro in livrosEncontrados)
            {
                Console.WriteLine(livro);
            }
        }
    }

    static void ExcluirLivro()
    {
        Console.Write("Digite o título do livro a ser excluído: ");
        string titulo = Console.ReadLine().ToLower();

        Livro livroParaExcluir = Livros.FirstOrDefault(l => l.Titulo.ToLower() == titulo);

        if (livroParaExcluir != null)
        {
            Livros.Remove(livroParaExcluir);
            Console.WriteLine("Livro excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
}

public class Livro
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int NumeroPaginas { get; set; }
    public int AnoPublicacao { get; set; }

    public override string ToString()
    {
        return $"Título: {Titulo}, Autor: {Autor}, Páginas: {NumeroPaginas}, Ano: {AnoPublicacao}";
    }
}
