using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Servico 
{
    private int idServico;
    private string titulo;
    private string descricao;

    private float valor;

    
    public int geraidAleatorio () {
        Random numAleatorio = new Random();
        int idAleatorio = numAleatorio.Next();
        return idAleatorio;
    }
    public Servico(int idserv, string tit, string desc, float v)
    {
        idServico = idserv;
        titulo = tit;
        descricao = desc;
        valor = v;
    }

    public Servico(string tit, string desc)
    {
        idServico = this.geraidAleatorio();
        titulo = tit;
        descricao = desc;
    }

    public int getId()
    {
        return idServico;
    }

    public string getTitulo()
    {
        return titulo;
    }

    public float getValor()
    {
        return valor;
    }

    public string formatLineCSV ()
    {
        return String.Format("{0};{1};{2};{3}", idServico, titulo, descricao, valor);
    }

    public void salvarServico() {
        FileStream meuArq = new FileStream("./arquivos/servicos.csv", FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
        

        sw.WriteLine(this.formatLineCSV());

        sw.Close();
        meuArq.Close();
    }

    public Servico addServico() {
        int idServico = this.geraidAleatorio();
        Console.WriteLine("\nADICIONAR SERVIÇO)");

        Console.Write("Título do Serviço: ");
        string titulo = Console.ReadLine();

        Console.Write("Descrição do Serviço: ");
        string descricao = Console.ReadLine();

        Console.Write("Valor do Serviço: ");
        string valor = Console.ReadLine();


        Servico novoServico = new Servico(
            idServico,
            titulo, 
            descricao,
            float.Parse(valor)
        );

        novoServico.salvarServico();
        src.Global.sessaoListaServicos.Add(novoServico);

        return novoServico;
        
    }

    public void printServico() {
        string print = string.Format("#({0}) {1} \n Titulo:{2} \n Descrição {3} \n Valor {4}",
        idServico, titulo, descricao, valor);
        
        Console.WriteLine(print);
    }

}

    

