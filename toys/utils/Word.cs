using Inputs;

namespace toys.utils;
//papagaio veio errado
public class Word
{
    private static string UserWord;

    public static void GetWordFromUser() => 
        UserWord = Input.String("Qual a palavra: ").Replace(" ", "") ?? "burro";
    
    
    public static List<char>? GetRepeatedOrEmpty()
    {
        // Retorna um array com as letras que repetem
        List<char> oldLetter = [];
        List<char> repeated = [];

        foreach (var character in UserWord)
        {
            if (oldLetter.Contains<char>(character))
            {
                if (!repeated.Contains(character))
                    repeated.Add(character);//é a primeira, colocar 2 vezes

                repeated.Add(character);
            }

            oldLetter.Add(character);
        }

        return repeated.Count == 0 ? null : repeated;
    }


  
    public static int GetAnagramsWithRepetitions()
    {
        var below = 1;
        var top = GetAnagramsWithoutRepetition();
        var repetitions = GetRepeatedOrEmpty();
        var currentFactorialCount = 0;

        List<char> AlreadyUsed = [];

        foreach (var letter in UserWord)
        {
            if (!AlreadyUsed.Contains(letter))
            {
                below  *= Factorial(currentFactorialCount);
                AlreadyUsed.Add(letter);
                currentFactorialCount = UserWord.Count(wordRepeated => wordRepeated == letter);
            }
        }

        return top / below;
    }
    
    
    public static int GetAnagramsWithoutRepetition() =>
        Factorial(UserWord.Length);


    public static string GetFormatedAnagramsWithRepetition()
    {
        var pointCount = 0;
        var anagrams = $"{GetAnagramsWithRepetitions()}";
        var result = "";
        for (var reverseIndex = anagrams.Length - 1; reverseIndex >= 0; reverseIndex--)
        {
            pointCount++;
            
            if (pointCount == 3 && reverseIndex > 0)
            {
                pointCount = 0;
                result += anagrams[reverseIndex] + ".";
            }
            else
                result += anagrams[reverseIndex];
        }
        
        Console.WriteLine(anagrams);

        var finalResult = "";

        foreach (var resultChar in result.Reverse())
            finalResult += resultChar;
        
        return finalResult;
    }
    
    public static string GetWord() => UserWord;

    
    private static int Factorial(int number)
    {
        var result = 1;
        while (number > 0)
        {
            result *= number;
            number--;
        }
        
        return result;
    }
}