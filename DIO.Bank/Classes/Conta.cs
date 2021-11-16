using DIO.Bank;
using System;

namespace DIO.Bank
{
  public class Conta
  {
    private ETipoConta TipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    public Conta(ETipoConta tipoConta, double saldo, double credito, string nome)
    {
      this.TipoConta = tipoConta;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }
    public bool Sacar(double valorSaque)
    {
      //Validação de Saldo Suficiente
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo Insuficiente!");

        return false;
      }

      this.Saldo -= valorSaque; // == SALDO = SALDO - VALORSAQUE;

      //Mesma operação da de cima
      //this.Saldo = this.Saldo - valorSaque;

      Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

      return true;
    }
    public void Depositar(double valorDeopositado)
    {
      this.Saldo += valorDeopositado;
      //MEsma operação de cima!
      //this.Saldo = Saldo + valorDeopositado;
      Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
    }
    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
      if (this.Sacar(valorTransferencia))
      {
        contaDestino.Depositar(valorTransferencia);
      }
    }

    // Override  ==  Sobrescreva
    public override string ToString()
    {
      string retorno = "";
      retorno += "TipoConta " + this.TipoConta + " | ";
      retorno += "Nome " + this.Nome + " | ";
      retorno += "Saldo " + this.Saldo + " | ";
      retorno += "Credito " + this.Credito + " | ";
      return retorno;
    }

  }
}
