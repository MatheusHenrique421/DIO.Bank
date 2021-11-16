using System.Collections.Generic;
using System;
namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpçãoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirContas();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentNullException();
        }
        opcaoUsuario = ObterOpçãoUsuario();
      }
      Console.WriteLine("Obrigado por Utilizar nossos Serviços. ");
      Console.ReadLine();
    }

    private static void ListarContas()
    {
      Console.WriteLine("Listar Contas:  ");
      if (listContas.Count == 0)
      {
        Console.WriteLine("Nenhuma Conta Cadastrada!!!!!!!!!!!!!");
        return;
      }

      for (int i = 0; i < listContas.Count; i++)
      {
        Conta conta = listContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }
    private static void InserirContas()
    {
      Console.WriteLine("Inserir Nova Conta");

      Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica:  ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Nome do Cliente:  ");
      string entradaNome = Console.ReadLine();

      Console.WriteLine("Digite o Saldo Inicial:  ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o crédito:  ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (ETipoConta)entradaTipoConta,
                                  saldo: entradaSaldo,
                                  credito: entradaCredito,
                                  nome: entradaNome);


      listContas.Add(novaConta);
    }
    private static void Transferir()
    {
      Console.Write("Digite o número da conta de Origen:  ");
      int indiceContaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de Destino:  ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser Transferindo:  ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
    }
    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].Sacar(valorSaque);
    }
    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser Depositado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].Depositar(valorSaque);
    }
    private static string ObterOpçãoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Bank a Seu DISPOR!!!!!");
      Console.WriteLine("Informe a opção Desejada");

      Console.WriteLine("1 - Listar Contas");
      Console.WriteLine("2 - Inserir uma Nova Conta");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;

    }

  }
}
