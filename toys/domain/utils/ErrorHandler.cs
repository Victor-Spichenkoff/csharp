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
            Console.WriteLine(myError.Message);;
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", myError.Label.Trim().Length)));
            Console.WriteLine("\n\n");
        }
        catch (JustBreak breakError)
        {
            Console.WriteLine("\n\n" + breakError.Message + "\n");
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