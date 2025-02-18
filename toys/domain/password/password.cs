using Inputs;

namespace toys.password;

public class Password
{
    private static Filters GetFilters()
    {
        var onlyNums = false;
        var onlyLower = false;
        var onlyUpper = false;
        var useSpecial = false;

        var size = Input.Int("Qual o tamanho? ");
        var full = Input.Bool("Completão [S/N] ");
        
        if (!full)
        {
            onlyNums = Input.Bool("Só números [S/N] ");
            if (!onlyNums)
                onlyLower = Input.Bool("Só minúsculas [S/N] ");
            if (!onlyLower && !onlyNums)
                onlyUpper = Input.Bool("Só maiúsculas [S/N] ");
            if (!onlyUpper && !onlyLower && !onlyNums)
                useSpecial = Input.Bool("Usar especiais [S/N] ");
        }


        return new Filters()
        {
            Size = size,
            onlyNumbers = onlyNums,
            onlyLowerCase = onlyLower,
            onlyUpperCase = onlyUpper,
            useSpecialChars = useSpecial
        };
    }

    public static void Principal()
    {
        var stop = false;

        while (!stop)
        {
            var filter = GetFilters();
            while (true)
            {
                var password = GeneratePassword.GenerateValidatedPassword(filter);
                Console.WriteLine("Final: " + password);
                var key = Input.String("Para sair/resetar [q/r]: ");
                if (key == "q")
                    stop = true;
                if (key == "q" || key == "r")
                    break;
            }
        }
    }
}