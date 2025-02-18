namespace toys.password;

public class Password
{
    public static void Principal()
    {
        while (true)
        {
            var filter = new Filters()
            {
                Size = 9
            };

            var password = GeneratePassword.CreateRandomFilteredPassword(filter);
            Console.WriteLine("Final: " + password);
            Console.Write("Para sair [q]: ");
            var key = Console.ReadLine();
            if(key == "q") break;
        }
    }
}