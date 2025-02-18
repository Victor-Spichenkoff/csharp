namespace toys.password;

public static class GeneratePassword
{
    private static char[] allCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{}|.<>?/".ToCharArray();

    private static char[] numbers = "0123456789".ToCharArray();
    private static char[] lowercaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private static char[] uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


    public static string GenerateValidatedPassword(Filters filter)
    {
        while (true)
        {
            var password = CreateRandomFilteredPassword(filter);
            var isValid = PasswordValidations.IsValidPassword(password);
            if(isValid)
                return password;
        }
    }
    
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

        for (var i = 0; i < filters.Size; i++)
        {
            if (filters.onlyNumbers)
                final += numbers[new Random().Next(0, numbers.Length - 1)];
            else if (filters.onlyLowerCase)
                final += lowercaseLetters[new Random().Next(0, lowercaseLetters.Length - 1)];
            else if (filters.onlyUpperCase)
                final += uppercaseLetters[new Random().Next(0, uppercaseLetters.Length - 1)];
            else if (!filters.useSpecialChars)
            {
                char[] allWithoutSpecial = [.. numbers, ..lowercaseLetters, ..uppercaseLetters];

                final += allWithoutSpecial[new Random().Next(0, allWithoutSpecial.Length - 1)];
            }
            else
                return CreateRandomFullPassword(filters.Size);
        }

        return final;
    }


    public static char[] GiveArrayBasedOnFilters(Filters filters)
    {
        if (filters.onlyLowerCase)
            return lowercaseLetters;
        else if (filters.onlyUpperCase)
            return uppercaseLetters;
        else if (filters.onlyNumbers)
            return numbers;
        else if (filters.useSpecialChars)
            return allCharacters;
        else
            return [.. numbers, ..lowercaseLetters, ..uppercaseLetters];
    }
}