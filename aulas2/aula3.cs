using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class aula3
{
    static int global = 17;
    static void Main()
    {
        Console.WriteLine(global);

        //operadores lógicos
        bool res = 0 < -1;

        Console.WriteLine(res);

        int n = 0;
        n++;
        Console.WriteLine(n);

        if(true | false) Console.WriteLine("Or");
        if(true & false) Console.WriteLine("And");


        //Formatar saída
        int n1, n2, n3;
        n1 = 7; 
        n2 = 12; 
        n3 = 17;
        
        Console.WriteLine("n1 = {0} \n\t n2 = {1} \n\t\t n3={2}", n1, n2, n3);

        int saldo = 565659910;
        // int saldo = "1231239102391.0";
        Console.WriteLine("Seu saldo, Victor, é:> {0, 10:c}", saldo);
        double pct = 17.22;
        Console.WriteLine("Seu saldo, Victor, é:> {0, 10:p}", pct);
    }        
}