using toys.password;

namespace Toys.Test.password;

public class GeneratePassword_test
{
    [Fact]
    public static void k()
    {
        var password = GeneratePassword.CreateRandomFullPassword(16);
    }
}