using System;

namespace Revisao
{
  class Program
  {
    static void Main(string[] args)
    {
      Aluno[] alunos = new Aluno[5];
      int indiceAluno = 0;

      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            Console.WriteLine("Qual o nome do aluno?");
            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();


            Console.WriteLine("Qual a Nota?");

            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
              aluno.Nota = nota;
            }
            else
            {
              throw new ArgumentException("Valor da nota deve ser decimal");
            }

            alunos[indiceAluno] = aluno;
            indiceAluno++;

            break;
          case "2":
            foreach (var listAlunos in alunos)
            {
              if (!string.IsNullOrEmpty(listAlunos.Nome))
              {
                Console.WriteLine($"Aluno: {listAlunos.Nome} - Nota: {listAlunos.Nota}");
              }
            }

            break;
          case "3":
            decimal notaTotal = 0;
            var nrAlunos = 0;
            for (int i = 0; i < alunos.Length; i++)
            {
              if (!string.IsNullOrEmpty(alunos[i].Nome))
              {
                notaTotal = notaTotal + alunos[i].Nota;
                nrAlunos++;
              }
            }

            var mediaGeral = notaTotal / nrAlunos;

            ConceitoEnun conceitoGeral;

            if (mediaGeral < 2)
            {
              conceitoGeral = ConceitoEnun.E;
            }
            else if (mediaGeral < 4)
            {
              conceitoGeral = ConceitoEnun.D;
            }
            else if (mediaGeral < 6)
            {
              conceitoGeral = ConceitoEnun.C;
            }
            else if (mediaGeral < 8)
            {
              conceitoGeral = ConceitoEnun.B;
            }
            else
            {
              conceitoGeral = ConceitoEnun.A;
            }

            Console.WriteLine($"Media da turma: {mediaGeral} - Conceito: {conceitoGeral}");

            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
    }

    private static string ObterOpcaoUsuario()
    {

      Console.WriteLine();
      Console.WriteLine("Informe uma opção");
      Console.WriteLine();
      Console.WriteLine("1-Inserir Novo Aluno");
      Console.WriteLine("2-Listar Alunos");
      Console.WriteLine("3-Apresentar Média Geral");
      Console.WriteLine("x-Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine();
      return opcaoUsuario;
    }
  }
}
