using System;
using System.IO;
using System.Text;

public class Animal {
    private int idPet;
    private string nomePet;

    private string portePet;

    private string infoAdicionalPet;

    private int idCliente;
    
    public Animal() {}

    public Animal(string noPet) {
        nomePet = noPet;
    }

    public Animal(int id, string noPet,  string pPet, string info, int idC) {
        idPet = id;
        nomePet = noPet;
        portePet = pPet;
        infoAdicionalPet = info;
        idCliente = idC;
    }

    public int geraidAleatorio () {
        Random numAleatorio = new Random();
        int idAleatorio = numAleatorio.Next();
        return idAleatorio;
    }

    public string getNomePet(){
        return nomePet;
    }

    public int getId(){
        return idPet;
    }

    public int getIdCliente(){
        return idCliente;
    }

    public string getPorte(){
        return portePet;
    }

    public string getInfoAdicional(){
        return infoAdicionalPet;
    }

    public void setNomePet(string novoNome){
        nomePet = novoNome;
    }

    public void print() {
        Console.WriteLine(this.getNomePet());
    }
}

public class Cachorro : Animal {
    private string racaCachorro;

    public Cachorro(int idP, string noPet,  string pPet, string info, int idC, string raca) : base(idP, noPet, pPet, info, idC)
    {
        racaCachorro = raca;
    }

    public string formatLineCSV ()
    {
        return String.Format("{0};{1};{2};{3};{4};{5}", this.getId(), this.getNomePet(), this.getPorte(), this.getInfoAdicional(), racaCachorro, this.getIdCliente());
    }

    public void salvarCachorro()
    {
        FileStream meuArq = new FileStream("./arquivos/cachorros.csv", FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
        

        sw.WriteLine(this.formatLineCSV());

        sw.Close();
        meuArq.Close();
    }

    public new void print() {
        Console.WriteLine(this.getNomePet());
    }
    
    public Cachorro addCachorro(Cliente cliente) {
        int idPet = this.geraidAleatorio();
        Console.WriteLine("\nADICIONAR CACHORRO/CADELA)");

        Console.Write("Nome: ");
        string nomePet = Console.ReadLine();

        Console.Write("Porte: ");
        string portePet = Console.ReadLine();

        Console.Write("Informação Adicional: ");
        string infoAdicionalPet = Console.ReadLine();

        Console.Write("Raça: ");
        string racaCachorro = Console.ReadLine();

        Cachorro novoCachorro = new Cachorro(
            idPet,
            nomePet, 
            portePet, 
            infoAdicionalPet, 
            cliente.Id,
            racaCachorro
        );

        novoCachorro.salvarCachorro();
        src.Global.sessaoListaAnimais.Add(novoCachorro);

        return novoCachorro;
    }
}

public class Gato : Animal {
    private string racaGato;

    public Gato(int idP, string noPet,  string pPet, string info, int idC, string raca) : base(idP, noPet, pPet, info, idC)
    {
        racaGato = raca;
    }

    public string formatLineCSV ()
    {
        return String.Format("{0};{1};{2};{3};{4};{5}", this.getId(), this.getNomePet(), this.getPorte(), this.getInfoAdicional(), racaGato, this.getIdCliente());
    }

    public void salvarGato()
    {
        FileStream meuArq = new FileStream("./arquivos/gatos.csv", FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
        

        sw.WriteLine(this.formatLineCSV());

        sw.Close();
        meuArq.Close();
    }

    public new void print() {
        Console.WriteLine(this.getNomePet());
    }

    public Gato addGato(Cliente cliente) {
        int idPet = this.geraidAleatorio();
        Console.WriteLine("\nADICIONAR GATO(A)");

        Console.Write("Nome: ");
        string nomePet = Console.ReadLine();

        Console.Write("Porte: ");
        string portePet = Console.ReadLine();

        Console.Write("Informação Adicional: ");
        string infoAdicionalPet = Console.ReadLine();

        Console.Write("Raça: ");
        string racaGato = Console.ReadLine();

        Gato novoGato = new Gato(
            idPet,
            nomePet, 
            portePet, 
            infoAdicionalPet,
            cliente.Id, 
            racaGato
        );

        novoGato.salvarGato();
        src.Global.sessaoListaAnimais.Add(novoGato);

        return novoGato;
    }
}