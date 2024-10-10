namespace Brincar.Aula_4;

class Aula_4
{
    public static void Contador_Vogal()
    {
        char[] vogais = ['a', 'e', 'i', 'o', 'u'];       
        int count = 0;
        string frase = Utils.Input("Qual a frase: ");

        foreach(var letra in frase.ToLower())
        {
            if(vogais.Contains(letra))
                count++;
        }

        Console.WriteLine($"Contagem de vogais em \"{frase}\" é {count}");

    }
}
