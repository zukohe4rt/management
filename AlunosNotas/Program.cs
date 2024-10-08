using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static List<Aluno> Alunos = [];

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("Gerenciamento de Alunos - Notas");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Adicionar Nota");
            Console.WriteLine("3. Exibir Alunos e Médias");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;
                case 2:
                    AdicionarNota();
                    break;
                case 3:
                    ExibirAlunosEMedias();
                    break;
                case 4:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 4);
    }

    static void CadastrarAluno()
    {
        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o número da matrícula: ");
        string matricula = Console.ReadLine();

        Aluno novoAluno = new()
        {
            Nome = nome,
            Matricula = matricula
        };

        Alunos.Add(novoAluno);
        Console.WriteLine("Aluno cadastrado com sucesso!");
    }

    static void AdicionarNota()
    {
        Console.Write("Digite o número da matrícula do aluno: ");
        string matricula = Console.ReadLine();

        Aluno aluno = Alunos.FirstOrDefault(a => a.Matricula == matricula);

        if (aluno != null)
        {
            Console.Write("Digite a nova nota: ");
            decimal nota = decimal.Parse(Console.ReadLine());
            aluno.AdicionarNota(nota);
            Console.WriteLine("Nota adicionada com sucesso!");
        }
        else
        {
            Console.WriteLine("Aluno não encontrado.");
        }
    }

    static void ExibirAlunosEMedias()
    {
        if (Alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
        }
        else
        {
            Console.WriteLine("Alunos e suas médias:");
            foreach (Aluno aluno in Alunos)
            {
                Console.WriteLine($"{aluno.Nome} (Matrícula: {aluno.Matricula}) - Média: {aluno.CalcularMedia():F2}");
            }
        }
    }
}

class Aluno
{
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public List<decimal> Notas { get; set; } = [];

    public void AdicionarNota(decimal nota)
    {
        Notas.Add(nota);
    }

    public decimal CalcularMedia()
    {
        if (Notas.Count == 0)
        {
            return 0;
        }
        return Notas.Average();
    }
}
