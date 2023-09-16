using System;
using System.Globalization;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;

namespace src
{
    public static class Global
    {
        public static Funcionario sessaoFuncionario;

        public static Cliente sessaoCliente;

        public static List<Animal> sessaoListaAnimais = new List<Animal>();

        public static List<Cliente> sessaoListaPessoas = new List<Cliente>();

        public static List<Funcionario> sessaoListaFuncionarios = new List<Funcionario>();

        public static List<Servico> sessaoListaServicos = new List<Servico>();

        public static List<Agendamento> sessaoListaAgendamentos = new List<Agendamento>();

        public static List<Venda> sessaoListaVendas = new List<Venda>();

        public static DateTime ReadScheduleDate()
        {
            DateTime scheduleDate;
            var dateFormats = new[] { "dd.MM.yyyy HH:mm", "dd-MM-yyyy HH:mm", "dd/MM/yyyy HH:mm" };

            while (true)
            {
                string readAddSchedule = AnsiConsole.Ask<string>("Qual a data e horário do serviço? [blue]dd/MM/yyyy HH:mm[/]");
                bool validDate = DateTime.TryParseExact
                (
                    readAddSchedule,
                    dateFormats,
                    DateTimeFormatInfo.InvariantInfo,
                    DateTimeStyles.None,
                    out scheduleDate
                );

                if (validDate) break;
                else AnsiConsole.WriteLine("[red]Data de agendamento inválida[/]");
            }

            return scheduleDate;
        }

    }

    class Program
    {
        static void MostrarDivisorTitulo(string text, string color = "red") {
            var rule = new Rule(string.Format("[{0}]{1}[/]", color, text ));
            rule.Alignment = Justify.Center;
            rule.Style = Style.Parse(string.Format("{0} dim", color));
            AnsiConsole.Write(rule);
        }

        static void VerVendas()
        {
            var table = new Table();

            table.AddColumn(new TableColumn("ID").Centered());
            table.AddColumn(new TableColumn("Data").Centered());
            table.AddColumn(new TableColumn("Serviço").Centered());
            table.AddColumn(new TableColumn("Valor").Centered());
            table.AddColumn(new TableColumn("Animal").Centered());
            table.AddColumn(new TableColumn("Cliente").Centered());

            foreach (var venda in Global.sessaoListaVendas.OrderBy(venda => venda.getAgendamento().getData()).ToList() )
            {

                table.AddRow(
                    Convert.ToString(venda.getId()),
                    Convert.ToString(venda.getAgendamento().getData()),
                    venda.getAgendamento().getServico().getTitulo(),
                    Convert.ToString(venda.getAgendamento().getServico().getValor()),
                    venda.getAgendamento().getAnimal().getNomePet(), 
                    venda.getCliente().Nome
                );
            }

            AnsiConsole.Write(table);
        }
        
        static void MenuFuncionario()
        {
            while(true)
            {
                var opcao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Por favor selecione uma opção para continuar:?")
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Fazer agendamento", 
                        "Visualizar agendamentos",
                        "Sair"
                    })
                );

                switch (opcao) {
                    case "Fazer agendamento":
                        Agendamento novoAgendamento = new Agendamento();
                        Cliente cliente = novoAgendamento.fazerAgendamento();

                        src.Global.sessaoListaAgendamentos.Add(novoAgendamento);
                        novoAgendamento.salvarAgendamento();


                        Venda venda = new Venda();
                        venda.fazerVenda(cliente, "Dinheiro", novoAgendamento);

                        break;
                    case "Visualizar agendamentos":
                        VerVendas();

                        break;
                    default:
                        break;
                }

                if(opcao == "Sair") {

                    break;
                }
            }
        }

        static void MenuEntrada()
        {
            bool estaLogado;

            var opcao = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Por favor selecione uma opção para continuar:?")
                .PageSize(10)
                .AddChoices(new[] {
                    "Sou Funcionario", "Sou Cliente"
                })
            );

            switch (opcao) 
            {
                case "Sou Funcionario":
                    Global.sessaoFuncionario = new Funcionario();

                    while (true)
                    {
                        string nome_usuario = AnsiConsole.Ask<string>("Insira o seu [green]nome de usuario[/]:");
                        var senha = AnsiConsole.Prompt(
                            new TextPrompt<string>("Insira a sua [green]senha[/]:")
                                .PromptStyle("red")
                                .Secret()
                        );

                        estaLogado = Global.sessaoFuncionario.Entrar(nome_usuario, senha);

                        if(estaLogado) break;

                        if (!estaLogado && !AnsiConsole.Confirm("Usuário não encontrado. Digitar novamente?"))
                        {
                            break;
                        }
                    }

                    if(estaLogado)
                    {
                        MostrarDivisorTitulo(string.Format("Olá {0}, seja bem vindo!", Global.sessaoFuncionario.Nome), "yellow");

                        Global.sessaoFuncionario.CarregarDadosSistema();

                        MenuFuncionario();
                    }
                    

                    break;
                case "Sou Cliente":
                    Global.sessaoCliente = new Cliente();

                    while (true)
                    {
                        string nome_usuario = AnsiConsole.Ask<string>("Insira o seu [green]nome de usuario[/]?");
                        var senha = AnsiConsole.Prompt(
                            new TextPrompt<string>("Insira a sua [green]senha[/]")
                                .PromptStyle("red")
                                .Secret()
                        );

                        estaLogado = Global.sessaoCliente.Entrar(nome_usuario, senha);

                        if(estaLogado) break;

                        if (!estaLogado && !AnsiConsole.Confirm("Usuário não encontrado. Digitar novamente?"))
                        {
                            break;
                        }
                    }

                    if(estaLogado)
                    {
                        MostrarDivisorTitulo(string.Format("Olá {0}, seja bem vindo!", Global.sessaoCliente.Nome), "yellow");

                        Global.sessaoCliente.CarregarDadosSistema();

                        VerVendas();
                    }

                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
        
            MenuEntrada();
        
            

            
        }
    }
}
