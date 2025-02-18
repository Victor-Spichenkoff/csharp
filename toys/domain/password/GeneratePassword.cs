namespace toys.password;

public static class GeneratePassword
{
    private static char[] allCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{}|,.<>?/".ToCharArray();

    private static char[] numbers = "0123456789".ToCharArray();
    private static char[] lowercaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static char[] uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


    public static string CreateRandomFullPassword(int size)
    {
        string final = "";

        for (int i = 0; i < size; i++)
            final += allCharacters[new Random().Next(0, allCharacters.Length - 1)];

        return final;
    }

    public static string CreateRandomFilteredPassword(Filters filters)
    {
        string final = "";

        for (var i = 0; i < filters.Size - 1; i++)
        {
            if (filters.onlyNumbers)
                final += numbers[new Random().Next(0, numbers.Length - 1)];
            else if (filters.onlyLowerCase)
                final += lowercaseLetters[new Random().Next(0, lowercaseLetters.Length - 1)];
            else if (filters.onlyUpperCase)
                final += uppercaseLetters[new Random().Next(0, uppercaseLetters.Length - 1)];
            else if (!filters.useSpecialChars)
            {
                var random = new Random();
                var useType = random.Next(1, 4);
                if (useType == 1)
                    final += numbers[new Random().Next(0, numbers.Length - 1)];
                else if (useType == 2)
                    final += uppercaseLetters[new Random().Next(0, uppercaseLetters.Length - 1)];
                else
                    final += lowercaseLetters[new Random().Next(0, lowercaseLetters.Length - 1)];
            }
            else
                return CreateRandomFullPassword(filters.Size);
        }

        return final;
    }
}