using System;
/*
qual operaçõ?
qauntos numeros
passa os nums
mais?

*/

class Mat 
{

}


class Calc 
{
    static void Main() 
    {
        int result;
        Console.Write("Qual a operação[s, l, m, d]: ");
        char operacao = (char)Console.ReadLine()[0];
        if(operacao == 's' || operacao == 'l') result =  0;
        else result = 1;
        goto skip;


        inicio:

        Console.Write("Qual a operação[s, l, m, d]: ");
        operacao = (char)Console.ReadLine()[0];

        skip:
        Console.Write("Quantos números: ");
        int qtdNums = int.Parse(Console.ReadLine());
        for(int i=0; i < qtdNums; i++)
        {
            Console.Write("Qual o número: ");
            int currentNumber = int.Parse(Console.ReadLine());
            if(operacao == 's') result+=currentNumber;
            if(operacao == 'l') result-=currentNumber;
            if(operacao == 'm') result*=currentNumber;
            if(operacao == 'd') result/=currentNumber;
        }

        Console.Clear();
        Console.WriteLine("Resultado atal:" + result);

        Console.Write("Mais[s, n]: ");
        char mais = (char)Console.ReadLine()[0];
        if(mais == 's') goto inicio;
        Console.Clear();
        Console.WriteLine("Valor final {0}", result);
        Console.WriteLine("FIM");
    }
}