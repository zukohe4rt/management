using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Produto> Produtos = new();
    static decimal totalVendas = 0;

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("Gerenciamento de Produtos e Vendas - Loja");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Registrar Venda");
            Console.WriteLine("3. Exibir Produtos e Estoque");
            Console.WriteLine("4. Exibir Total de Vendas");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    RegistrarVenda();
                    break;
                case 3:
                    ExibirProdutos();
                    break;
                case 4:
                    ExibirTotalVendas();
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

    static void CadastrarProduto()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o preço do produto: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        Console.Write("Digite a quantidade em estoque: ");
        int quantidade = int.Parse(Console.ReadLine());

        Produto novoProduto = new()
        {
            Nome = nome,
            Preco = preco,
            QuantidadeEstoque = quantidade
        };

        Produtos.Add(novoProduto);
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void RegistrarVenda()
    {
        Console.Write("Digite o nome do produto vendido: ");
        string nome = Console.ReadLine();

        Produto produto = Produtos.FirstOrDefault(p => p.Nome.ToLower() == nome.ToLower());

        if (produto != null)
        {
            Console.Write("Digite a quantidade vendida: ");
            int quantidadeVendida = int.Parse(Console.ReadLine());

            if (produto.QuantidadeEstoque >= quantidadeVendida)
            {
                produto.Vender(quantidadeVendida);
                totalVendas += produto.Preco * quantidadeVendida;
                Console.WriteLine($"Venda registrada! {quantidadeVendida} unidade(s) de {produto.Nome} vendida(s).");
            }
            else
            {
                Console.WriteLine("Quantidade em estoque insuficiente para a venda.");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    static void ExibirProdutos()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            Console.WriteLine("Produtos disponíveis:");
            foreach (Produto produto in Produtos)
            {
                Console.WriteLine($"{produto.Nome} - Preço: {produto.Preco:C2}, Estoque: {produto.QuantidadeEstoque}");
            }
        }
    }

    static void ExibirTotalVendas()
    {
        Console.WriteLine($"Total de vendas realizadas: {totalVendas:C2}");
    }
}

class Produto
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }

    public void Vender(int quantidade)
    {
        QuantidadeEstoque -= quantidade;
    }
}
