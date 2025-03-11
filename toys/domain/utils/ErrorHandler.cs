namespace toys.utils;

public class ErrorHandler
{
    public static void ShowError(Exception err)
    {
        try
        {
            throw err;
        }
        catch (MyError myError)
        {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(myError.Label);
            Console.WriteLine(myError.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.Source);
            Console.WriteLine("=========== Something went wrong ===========");
        }
    }
}