using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Constants
{
    public readonly static string[] TIPOSANIMAIS = { "Cachorro", "Gato" };

    public readonly static string[] PORTEANIMAL = { "Mini", "Pequeno", "Médio", "Grande" };

    public readonly static string[] FORMASPAGAMENTOS = { "Dinheiro", "Débito", "Crédito", "Pix", "PicPay" };
}

public class Pessoa 
{
    private string perfil;
    public string Perfil
    {
        get { return perfil; }
        set { perfil = value; }
    }
    
    private string nomeUsuario;
    public string NomeUsuario
    {
        get { return nomeUsuario; }
        set { nomeUsuario = value; }
    }
    private string senha;
    public string Senha
    {
        get { return senha; }
        set { senha = value; }
    }
    private string nome;
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    private string cpf;
    public string Cpf
    {
        get { return cpf; }
        set { cpf = value; }
    }

    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public Pessoa() {}

    public Pessoa(string u, string n, string s) 
    {
        nomeUsuario = u;
        nome = n;
        senha = s;
    }

    public Pessoa(string n, string cpf1) 
    {
        nome = n;
        cpf = cpf1;
    }

    public bool Entrar(string u, string s)
    {
        FileStream meuArq = new FileStream("./arquivos/clientes.csv", FileMode.Append, FileAccess.Read);
        StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
        
        while(!sr.EndOfStream){
            string[] str = sr.ReadLine().Split(";");
            if(str[1] == u && str[2] == s) 
            {
                id = int.Parse(str[0]);
                nomeUsuario = str[1];
                senha = str[2];
                nome = str[3];
                cpf = str[4];

                return true;
            }
        }

        sr.Close();
        meuArq.Close();

        return false;
    }

    public void CarregarDadosSistema() 
    {
        this.CarregarServicos();
    }

    public void CarregarServicos()
    {
        FileStream arq = new FileStream("./arquivos/servicos.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(arq, Encoding.UTF8);

        while(!sr.EndOfStream){
            string[] linha = sr.ReadLine().Split(";");

            Servico novoServico = new Servico(int.Parse(linha[0]), linha[1], linha[2], float.Parse(linha[3]));

            src.Global.sessaoListaServicos.Add(novoServico);
        }

        sr.Close();
        arq.Close();
    }




    
}

public class Cliente : Pessoa 
{
    public Cliente() { }

    public Cliente(int id, string u, string n, string s, string c) 
    {
        this.Id = id;
        this.NomeUsuario = u;
        this.Nome = n;
        this.Cpf = c;
    }

    public new bool Entrar(string u, string s)
    {
        FileStream meuArq = new FileStream("./arquivos/clientes.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
        
        while(!sr.EndOfStream){
            string[] str = sr.ReadLine().Split(";");
            if(str[1] == u && str[2] == s) 
            {
                this.Id = int.Parse(str[0]);
                this.NomeUsuario = str[1];
                this.Senha = str[2];
                this.Nome = str[3];
                this.Cpf = str[4];

                return true;
            }
        }

        sr.Close();
        meuArq.Close();

        return false;
    }
    

    public new void CarregarDadosSistema() 
    {
        this.CarregarGatos();
        this.CarregarCachorros();

        this.CarregarServicos();
        this.CarregarAgendamentos();
        this.CarregarVendas();
    }

    public void CarregarGatos() 
    {
        FileStream arqGatos = new FileStream("./arquivos/gatos.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srGatos = new StreamReader(arqGatos, Encoding.UTF8);

        while(!srGatos.EndOfStream){
            string[] linhaGato = srGatos.ReadLine().Split(";");

            if(int.Parse(linhaGato[5]) == src.Global.sessaoCliente.Id) {
                Gato novoGato = new Gato(int.Parse(linhaGato[0]), linhaGato[1], linhaGato[2], linhaGato[3], src.Global.sessaoCliente.Id, linhaGato[4]);

                src.Global.sessaoListaAnimais.Add(novoGato);
            }

            
        }

        srGatos.Close();
        arqGatos.Close();
    }

    public void CarregarCachorros() 
    {
        FileStream arqCachorros = new FileStream("./arquivos/cachorros.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srCachorros = new StreamReader(arqCachorros, Encoding.UTF8);

        while(!srCachorros.EndOfStream){
            string[] linhaCachorro = srCachorros.ReadLine().Split(";");

            if(int.Parse(linhaCachorro[5]) == src.Global.sessaoCliente.Id) {
                Cachorro novoCachorro = new Cachorro(int.Parse(linhaCachorro[0]), linhaCachorro[1], linhaCachorro[2], linhaCachorro[3], src.Global.sessaoCliente.Id, linhaCachorro[4]);

                src.Global.sessaoListaAnimais.Add(novoCachorro);
            }
            
        }

        srCachorros.Close();
        arqCachorros.Close();
    }

    public void CarregarAgendamentos()
    {
        FileStream arq = new FileStream("./arquivos/agendamentos.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(arq, Encoding.UTF8);

        while(!sr.EndOfStream){
            string[] linha = sr.ReadLine().Split(";");
            Servico servico = src.Global.sessaoListaServicos.First(x => x.getId() == int.Parse(linha[1]));
            Animal animal = src.Global.sessaoListaAnimais.First(x => x.getIdCliente() == src.Global.sessaoCliente.Id);
            
            Agendamento novoAgendamento = new Agendamento(int.Parse(linha[0]), servico, DateTime.Parse(linha[2]), animal);

            src.Global.sessaoListaAgendamentos.Add(novoAgendamento);
        }

        sr.Close();
        arq.Close();
    }

    public void CarregarVendas()
    {
        FileStream arq = new FileStream("./arquivos/vendas.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(arq, Encoding.UTF8);

        while(!sr.EndOfStream){
            string[] linha = sr.ReadLine().Split(";");

            if(int.Parse(linha[1]) == src.Global.sessaoCliente.Id)
            {
                Agendamento agendamento = src.Global.sessaoListaAgendamentos.First(x => x.getId() == int.Parse(linha[4]));

                Venda novaVenda = new Venda(int.Parse(linha[0]), src.Global.sessaoCliente, linha[2], agendamento);

                src.Global.sessaoListaVendas.Add(novaVenda);
            }
        }

        sr.Close();
        arq.Close();
    }
}

public class Funcionario : Pessoa 
{
    public Funcionario() { }

    public Funcionario(int id, string u, string n, string s, string c) 
    {
        this.Id = id;
        this.NomeUsuario = u;
        this.Nome = n;
        this.Cpf = c;
    }

    public new bool Entrar(string u, string s)
    {
        FileStream meuArq = new FileStream("./arquivos/funcionarios.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
        
        while(!sr.EndOfStream){
            string[] str = sr.ReadLine().Split(";");
            if(str[1] == u && str[2] == s) 
            {
                this.Id = int.Parse(str[0]);
                this.NomeUsuario = str[1];
                this.Senha = str[2];
                this.Nome = str[3];
                this.Cpf = str[4];

                return true;
            }
        }

        sr.Close();
        meuArq.Close();

        return false;
    }

    public new void CarregarDadosSistema() 
    {
        this.CarregarFuncionarios();
        this.CarregarClientes();
        
        this.CarregarGatos();
        this.CarregarCachorros();

        this.CarregarServicos();

        this.CarregarAgendamentos();
        this.CarregarVendas();
    }

    public void CarregarGatos() 
    {
        FileStream arqGatos = new FileStream("./arquivos/gatos.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srGatos = new StreamReader(arqGatos, Encoding.UTF8);

        while(!srGatos.EndOfStream){
            string[] linhaGato = srGatos.ReadLine().Split(";");

            Cliente cliente = src.Global.sessaoListaPessoas.First(x => x.Id == int.Parse(linhaGato[5]));
            Gato novoGato = new Gato(int.Parse(linhaGato[0]), linhaGato[1], linhaGato[2], linhaGato[3], cliente.Id, linhaGato[4]);

            src.Global.sessaoListaAnimais.Add(novoGato);
        }

        srGatos.Close();
        arqGatos.Close();
    }

    public void CarregarCachorros() 
    {
        FileStream arqCachorros = new FileStream("./arquivos/cachorros.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srCachorros = new StreamReader(arqCachorros, Encoding.UTF8);

        while(!srCachorros.EndOfStream){
            string[] linhaCachorro = srCachorros.ReadLine().Split(";");

            Cliente cliente = src.Global.sessaoListaPessoas.First(x => x.Id == int.Parse(linhaCachorro[5]));

            Cachorro novoCachorro = new Cachorro(int.Parse(linhaCachorro[0]), linhaCachorro[1], linhaCachorro[2], linhaCachorro[3], cliente.Id, linhaCachorro[4]);
            src.Global.sessaoListaAnimais.Add(novoCachorro);
        }

        srCachorros.Close();
        arqCachorros.Close();
    }

    public void CarregarClientes()
    {
        FileStream arqClientes = new FileStream("./arquivos/clientes.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srClientes = new StreamReader(arqClientes, Encoding.UTF8);

        while(!srClientes.EndOfStream){
            string[] linha = srClientes.ReadLine().Split(";");

            Cliente novoCliente = new Cliente(int.Parse(linha[0]), linha[1], linha[3], linha[2], linha[4]);

            src.Global.sessaoListaPessoas.Add(novoCliente);
        }

        srClientes.Close();
        arqClientes.Close();
    }

    public void CarregarFuncionarios()
    {
        FileStream arqFuncionarios = new FileStream("./arquivos/funcionarios.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader srFuncionarios = new StreamReader(arqFuncionarios, Encoding.UTF8);

        while(!srFuncionarios.EndOfStream){
            string[] linha = srFuncionarios.ReadLine().Split(";");

            Funcionario novoFuncionario = new Funcionario(int.Parse(linha[0]), linha[1], linha[3], linha[2], linha[4]);

            src.Global.sessaoListaFuncionarios.Add(novoFuncionario);
        }

        srFuncionarios.Close();
        arqFuncionarios.Close();
    } 

    public void CarregarAgendamentos()
    {
        FileStream arq = new FileStream("./arquivos/agendamentos.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(arq, Encoding.UTF8);

        while(!sr.EndOfStream){
            string[] linha = sr.ReadLine().Split(";");

            if(linha.Length >= 4) {
                Servico servico = src.Global.sessaoListaServicos.First(x => x.getId() == int.Parse(linha[1]));
            
                Animal animal = src.Global.sessaoListaAnimais.First(x => x.getId() == int.Parse(linha[3]));

                Agendamento novoAgendamento = new Agendamento(int.Parse(linha[0]), servico, DateTime.Parse(linha[2]), animal);

                src.Global.sessaoListaAgendamentos.Add(novoAgendamento);
            }
        }

        sr.Close();
        arq.Close();
    }

    public void CarregarVendas()
    {
        FileStream arq = new FileStream("./arquivos/vendas.csv", FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(arq, Encoding.UTF8);

        while(!sr.EndOfStream){
            string[] linha = sr.ReadLine().Split(";");

            if(linha.Length >= 5) {
                Cliente cliente = src.Global.sessaoListaPessoas.First(x => x.Id == int.Parse(linha[1]));
                Agendamento agendamento = src.Global.sessaoListaAgendamentos.First(x => x.getId() == int.Parse(linha[4]));
                Venda novaVenda = new Venda(int.Parse(linha[0]), cliente, linha[2], agendamento);

                src.Global.sessaoListaVendas.Add(novaVenda);
            }  
        }

        sr.Close();
        arq.Close();
    }
}
