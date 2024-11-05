using Inputs;
using toys.utils;

namespace toys;

public static class Anagrams
{
    private static void GetOneAnagram()
    {
        Word.GetWordFromUser();

        var repetitions = Word.GetRepeatedOrEmpty();
        var word = Word.GetWord();

        var resultString = "";
        
        if (repetitions == null)
            resultString = $"Anagramas da palavra {word.ToUpper()}: {Word.GetAnagramsWithoutRepetition()}";
        else
            resultString = $"Anagramas da palavra {word.ToUpper()}: {Word.GetFormatedAnagramsWithRepetition()}";
            
        Console.WriteLine(resultString);
    }

    public static void Principal()
    {
        while (true)
        {
            GetOneAnagram();

            var again = Input.String("Mais uma vez?[s/n]: ");
            if(again == "n")
                return;
        }
    }
}