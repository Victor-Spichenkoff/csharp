using System;
//using Lista;
using Lista.Arrays;




//dotnet run -- --no-list
class Program
{
    static void Main(string[] args)
    {
        if(!args.Contains("--no-list"))
        Arrays.Execute();
    }
}
