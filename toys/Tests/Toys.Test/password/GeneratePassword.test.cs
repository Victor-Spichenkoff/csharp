using toys.password;

namespace Toys.Test.password;

public class GeneratePassword_test
{
    [Theory]
    [InlineData(true, false, false, false)]
    [InlineData(false, true, false, false)]
    [InlineData(false, false, true, false)]
    [InlineData(false, false, false, true)]
    [InlineData(false, true, false, true)]//grande duvida
    public static void ShouldGiveOnlyCorrectValuesBaseOnFilters(
        bool nums, bool lower, bool upper, bool special
        )
    {
        var filter = new Filters()
        {
            onlyNumbers = nums,
            onlyLowerCase = lower,
            onlyUpperCase = upper,
            useSpecialChars = special,
        };
        
        IList<string> results = new List<string>();
        
        for(int i = 0; i < 3; i++)
            results.Add(GeneratePassword.CreateRandomFilteredPassword(filter));
        
        bool isError = false;

        foreach (var password in results)
        {
            var arrayForType = GeneratePassword.GiveArrayBasedOnFilters(filter);

            foreach (var letter in password)
                if (!arrayForType.Contains(letter))
                {
                    isError = true;
                    break;
                }
        }
        
        Assert.False(isError);
    }
}