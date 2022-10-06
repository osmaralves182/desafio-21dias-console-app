using System;

namespace console_desafio21dias_api
{
  class Program
  {
    static void Main(string[] args)
    {

      // Aula 3 - Loop | Minuto: 33 Minutos
      Console.WriteLine("Digite o número inicial: ");
      int numeroInicial = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Digite o número final: ");
      int numeroFinal = Convert.ToInt32(Console.ReadLine());

      int indice = numeroInicial;

      while (indice <= numeroFinal)
      {
        Console.WriteLine(indice);
        indice++;
      }

      do
      {
        Console.WriteLine(indice);
        indice++;
      } while (indice <= numeroFinal);

      for (int i = numeroInicial; i < numeroFinal; i++)
      {
        Console.WriteLine(i);
      }

      int[] itens = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      foreach (var item in itens)
      {
        Console.WriteLine(item);
      }

      // Não é tão usada
      /*string [][] alunos = new string [5][5];

      alunos[0][0] = "Osmar";
      alunos[1][0] = "123";
      alunos[2][0] = "10, 9, 8";*/

      List<dynamic> alunos = new List<dynamic>();

      alunos.Add(new
      {
        Nome = "Osmar",
        Matricula = "001",
        Notas = "10,9,8"
      });

      alunos.Add(new
      {
        Nome = "Maria",
        Matricula = "001",
        Notas = "10,9,8"
      });

      alunos.Add(new
      {
        Nome = "Sheila",
        Matricula = "001",
        Notas = "10,9,8"
      });

      foreach (var aluno in alunos)
      {
        Console.WriteLine($"Nome do aluno: {aluno.Nome}");
        Console.WriteLine($"Matrícula do aluno: {aluno.Matricula}");
        Console.WriteLine($"Notas do aluno: {aluno.Notas}");
        Console.WriteLine($"---------------------------------");
      }

      //Aula 1 e 2
      /*Console.WriteLine("Digite o primeiro valor:");
      int n1 = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Digite o segundo valor:");
      int n2 = Convert.ToInt32(Console.ReadLine());

      int soma = n1 * n2;

      Console.WriteLine($"Qual é o resultado da soma dos números {n1} e {n2}?");
      Console.WriteLine($"Digite o número premiado?");
      int resultado = Convert.ToInt32(Console.ReadLine());

      if (soma == resultado || resultado == 1 || resultado == 10)
      {
        Console.WriteLine($"Parabéns, você acertou!. A soma dos valores é {soma}!");
      }
      else
      {
        Console.WriteLine($"Você errou. Tente novamente na próxima!");
      }*/
    }
  }
}
