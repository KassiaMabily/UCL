using System;
using Spectre.Console;
using System.IO;
using System.Text;
using System.Linq;

public class Agendamento 
{
    private int id;

    private Servico servico;
    private DateTime data;

    private Animal animal;

    public int geraidAleatorio () {
        Random numAleatorio = new Random();
        int idAleatorio = numAleatorio.Next();
        return idAleatorio;
    }

    public Agendamento() {
    }

    public Agendamento(int i, Servico serv, DateTime d, Animal a) {
        id = i;
        servico = serv;
        data = d;
        animal = a;
    }

    public Agendamento(Servico serv, DateTime d, Animal a) {
        id = geraidAleatorio();
        servico = serv;
        data = d;
    }

    public Animal getAnimal()
    {
        return animal;
    }

    public DateTime getData()
    {
        return data;
    }

    public Servico getServico()
    {
        return servico;
    }

    public int getId()
    {
        return id;
    }

    public string formatLineCSV ()
    {
        return String.Format("{0};{1};{2};{3}", id, servico.getId(), data, animal.getId());
    }

    public void salvarAgendamento() 
    {
        FileStream meuArq = new FileStream("./arquivos/agendamentos.csv", FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
        

        sw.WriteLine(this.formatLineCSV());

        sw.Close();
        meuArq.Close();
    }

    public Cliente fazerAgendamento()
    {
        var nome_serv = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Serviço")
            .PageSize(10)
            .AddChoices(src.Global.sessaoListaServicos.Select(x => x.getTitulo()).ToArray())
        );

        Servico serv = src.Global.sessaoListaServicos.First(x => x.getTitulo() == nome_serv);

        var nome_cliente = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Cliente")
            .PageSize(10)
            .AddChoices(src.Global.sessaoListaPessoas.Select(x => x.Nome).ToArray())
        );

        Cliente cliente = src.Global.sessaoListaPessoas.First(x => x.Nome == nome_cliente);

        var nome_animal = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Animal")
            .PageSize(10)
            .AddChoices(src.Global.sessaoListaAnimais.FindAll( x => x.getIdCliente() == cliente.Id).Select(x => x.getNomePet()).ToArray())
        );

        Animal nanimal = src.Global.sessaoListaAnimais.First(x => x.getNomePet() == nome_animal && x.getIdCliente() == cliente.Id);
        DateTime dataAgendamento = src.Global.ReadScheduleDate();

        this.id = geraidAleatorio();
        this.servico = serv;
        this.data = dataAgendamento;
        this.animal = nanimal;

        return cliente;
    }
}

public class Venda  {
    private int idvendaServ;
    private Cliente cliente;
    private float valorTotal;
    private string formapagamento;
    private Agendamento agendamento;
    private DateTime datavenda;

    public int geraidAleatorio () {
        Random numAleatorio = new Random();
        int idAleatorio = numAleatorio.Next();
        return idAleatorio;
    }

    public Venda(){
    }

    public Venda(int id, Cliente client, string fmpgto, Agendamento ag){
        idvendaServ = id;
        datavenda = DateTime.Now;
        cliente = client;
        valorTotal = ag.getServico().getValor();
        formapagamento = fmpgto;
        agendamento = ag;
    }

    public Venda(Cliente client, string fmpgto, Agendamento ag){
        idvendaServ = this.geraidAleatorio();
        datavenda = DateTime.Now;
        cliente = client;
        valorTotal = ag.getServico().getValor();
        formapagamento = fmpgto;
        agendamento = ag;
    }

    public int getId()
    {
        return idvendaServ;
    }

    public Agendamento getAgendamento()
    {
        return agendamento;
    }

    public Cliente getCliente()
    {
        return cliente;
    }

    public string formatLineCSV ()
    {
        return String.Format("{0};{1};{2};{3};{4};{5}", this.idvendaServ, this.cliente.Id, this.valorTotal, this.formapagamento, this.agendamento.getId(), this.datavenda);
    }

    public void salvarVenda() {
        FileStream meuArq = new FileStream("./arquivos/vendas.csv", FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
        

        sw.WriteLine(this.formatLineCSV());

        sw.Close();
        meuArq.Close();
    }

    public void fazerVenda(Cliente client, string fmpgto, Agendamento ag)
    {
        this.idvendaServ = this.geraidAleatorio();
        this.datavenda = DateTime.Now;
        this.cliente = client;
        this.valorTotal = ag.getServico().getValor();
        this.formapagamento = fmpgto;
        this.agendamento = ag;

        this.salvarVenda();
        src.Global.sessaoListaVendas.Add(this);
    }
}