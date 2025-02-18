using toys.password;

namespace Toys.Test.password;

public class GeneratePassword_test
{
    [Theory]
    [InlineData(true, false, false, false)]
    [InlineData(false, true, false, false)]
    [InlineData(false, false, true, false)]
    [InlineData(false, false, false, true)]
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
        
        for(int i = 0; i < 20; i++)
            results.Add(GeneratePassword.CreateRandomFilteredPassword(filter));
        
        bool isError = false;

        var arrayForType = GeneratePassword.GiveArrayBasedOnFilters(filter);
        foreach (var password in results)
        {

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