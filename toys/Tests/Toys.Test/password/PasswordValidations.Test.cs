using toys.password;

namespace Toys.Test.password;

public class PasswordValidationsTest
{
    [Theory]
    [InlineData("yuyi")]
    [InlineData("vssvv")]
    [InlineData("vffvvv")]
    [InlineData("jjklghfds")]
    [InlineData("eeee")]
    public void PasswordPercentValidation_ShouldFail(string password)
    {
        var isValid = PasswordValidations.IsValidPassword(password);
        
        Assert.False(isValid);
    }
    
    
    [Theory]
    [InlineData("aaluioplkjhgf")]
    [InlineData("aaluioplkjhgf")]
    [InlineData("luiopaalkjhgf")]
    [InlineData("aaluioplkjhgfaa")]
    public void PasswordRepetionValidation_ShouldFail(string password)
    {
        var isValid = PasswordValidations.IsValidPassword(password);
        
        Assert.False(isValid);
    }
    
    
    [Theory]
    [InlineData("qwertyuaia")]//teste de percent
    [InlineData("qwertyuaiatamnb")]//teste de seguidos
    public void ShouldPass(string password)
    {
        var isValid = PasswordValidations.IsValidPassword(password);
        
        Assert.True(isValid);
    }


    [Fact]
    public void TestOn20PasswordShouldWork()
    {
        var filter = new Filters()
        {
            Size = 20
        };
        
        IList<string> results = new List<string>();
        
        for(int i = 0; i < 20; i++)
            results.Add(GeneratePassword.GenerateValidatedPassword(filter));
        
        bool isError = false;
        
        foreach (var password in results)
        {
            var isValid = PasswordValidations.IsValidPassword(password);
            if (!isValid)
            {
                isError = true;
                break;
            }
        }
        
        Assert.False(isError);
    }
}