using System;

// [15%]. Implemente a classe Aeronave, que deve conseguir representar as seguintes características:

// Nome da Aeronave. 
// Capacidade Máxima do Tanque de Combustível (em litros). 
// O nível atual do tanque de combustível em percentual.
// O consumo médio (em km/litro) de combustível da aeronave.
// Quantidade de Passageiros que a aeronave suporta.
// Autonomia da Aeronave, que identifica a quantidade de Km que ela ainda pode voar sem abastecer.
// O número de Horas de Voo, que conta quantos quilômetros a aeronave já percorreu em sua vida útil.

class Aeronave {
    private string nome;
    private float capacidadeMaximaTanque;
    private float nivelAtualTanque;
    private float consumoMedio;
    private int qtdMaxPassageiros;
    private float autonomia;
    private float qtdHorasVoo;


    // [15%]. Crie dois construtores para a classe, um default (construtor padrão) e outro completo, compreendendo todos os atributos da classe;
    //Construtor Default (padrão):  
    public Aeronave(){
        nome = "<nome não definido>";
        capacidadeMaximaTanque = 10000f;
        nivelAtualTanque = 0f;
        consumoMedio = 500f;
        qtdMaxPassageiros = 250;
        qtdHorasVoo = 0f;
        calcularAutonomia();
    }

    // Construtor completo
    public Aeronave(string n, float cMaxTanque, float nAtualTanque, float cMedio, int qtdMaxPas, float qtdHsVoo){
        nome = n;

        if(cMaxTanque >=0)
            capacidadeMaximaTanque = cMaxTanque;

        if(nAtualTanque >= 0f && nAtualTanque <= 100f)
            nivelAtualTanque = nAtualTanque;
    
        if(cMedio >= 0)
            consumoMedio = cMedio;
    
        if(qtdMaxPas >= 0)
            qtdMaxPassageiros = qtdMaxPas;
    
        if(qtdHsVoo >= 0)
            qtdHorasVoo = qtdHsVoo;
    
        calcularAutonomia();
    }

    // [15%]. Crie os métodos de acesso (get/set) para:
    // Acessar e alterar o nome da aeronave;
    public string getNome() {
        return nome;
    }

    public void setNome(string n){
        nome = n;
    }

    // Acessar e alterar a quantidade de passageiros que a aeronave suporta;
    public int getQtdMaxPassageiros(){
        return qtdMaxPassageiros;
    }

    public bool setQtdMaxPassageiros(int qtd){
        if(qtd > 0) {
            qtdMaxPassageiros = qtd;
            return true;
        }
        return false;
    }

    // [20%]. Crie o método void TranseferirCombustível(Aeronave destino), que transfere o combustível presente 
    // na aeronave de origem para a aeronave de destino (informada como parâmetro). 
    // Só deve ser possível realizar a transferência se a aeronave de destino estiver com o tanque vazio 
    // e se suportar a quantidade de combustível presente na aeronave de origem (responsável por chamar o método).
    // Obs.: lembre-se que o nível atual de combustível é dado em percentual. Faça as devidas conversões.
    public void TransferirCombustivel(Aeronave aeronave_destino){
        float nivel_tanque_litros = (this.nivelAtualTanque * this.capacidadeMaximaTanque) / 100f;

        if(aeronave_destino.nivelAtualTanque == 0f && aeronave_destino.capacidadeMaximaTanque >= nivel_tanque_litros) {
            this.nivelAtualTanque = 0.0f;
            aeronave_destino.nivelAtualTanque = nivel_tanque_litros / aeronave_destino.capacidadeMaximaTanque;

            // deve ser calculada novamente:
            aeronave_destino.calcularAutonomia();
            this.calcularAutonomia();
        }
    }

    // [25%]. Crie o método Voar, que recebe como parâmetro uma distância em km a ser percorrida pela aeronave 
    // e retorna a quantidade total de horas de voo da aeronave atualizada.
    // As seguintes regras devem ser observadas:
    // A aeronave só pode voar se a distância for menor ou igual à autonomia da aeronave. 
    // Deve ser atualizado o nível de combustível presente no tanque com base na distância percorrida e no consumo médio da aeronave.
    // Deve ser atualizada a quantidade total de horas de voo da aeronave.

    public void calcularAutonomia(){
        float nivel_tanque_litros = (nivelAtualTanque * capacidadeMaximaTanque) / 100f; 
        autonomia =  nivel_tanque_litros * consumoMedio;
    }

    public float Voar(float distancia){
        if(distancia <= autonomia){

            //Atualização do nível de combustível:
            float qtdLitrosVoo = distancia / consumoMedio;
            nivelAtualTanque = nivelAtualTanque - (qtdLitrosVoo/capacidadeMaximaTanque)*100;

            //Atualização do número de horas de voo com o acrescimo deste voo:
            qtdHorasVoo += distancia;

            // A autonomia deve ser atualizada sempre que houver modificação na quantidade de combustível:
            calcularAutonomia();
        }    

        return qtdHorasVoo;
    }

    public string PrintAeronave(){
        string ficha = string.Format("Modelo:                        {0}\n"+
                                    "Capacidade de Abastecimento:   {1:#,0.00} lts\n"+
                                    "Nível Tanque:                  {2:0.00%}\n"+
                                    "Consumo Médio:                 {3} km/l\n"+
                                    "Capacidade máxima passageiros: {4}\n"+
                                    "Autonomia:                     {5:#,0.00} km\n"+
                                    "Horas totais de voo:           {6:#,0} hrs\n"+
                                    "______________________________________\n"+
                                    "\n",  
                                    nome, capacidadeMaximaTanque, nivelAtualTanque, consumoMedio, qtdMaxPassageiros, autonomia, qtdHorasVoo);
        return ficha;
}    
}