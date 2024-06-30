using System;

public interface IVeiculo 
{
    // não coloca variaveis nela, só metodos
    void ligar();
    void desligar();
    void info(); 

}

public interface ICombate 
{
    void disparar();
}


// class Carro: IVeiculo {
//     public Carro() 
//     {
        
//     }
// }


// public class TesteInterfaces
// {
//     static void Main()
//     {
//         Carro c1 = new Carro();
//     }    
// }
