using Inputs;
using toys.utils;

namespace toys.banco.types;

public class Digital : BaseAccount
{
    public Digital(int id, string holder, double balance, double specialCheck) : base(id, AccountType.Digital, holder,
        balance, specialCheck)
    {
    }

    public override bool Sake(SakeCallback? callback = null)
    {
        return base.Sake(SakeCallback);
    }

    private double SakeCallback(double startValue)
    {
        const double atmTax = 6.9; 
        Console.WriteLine("[ 1 ] - PIX");
        Console.WriteLine("[ 2 ] - ATM");
        var isPix = Input.String("What type: ") == "1";

        var final = startValue;
        if (!isPix)
        {
            final = startValue + atmTax;
            var proceed = Input.BoolEnglish($"Withdraw ${startValue} with tax of ${atmTax} is ${final}. Continue [y/n]? ");

            if (!proceed)
                throw new MyError("Withdraw cancelled!");
        }

        return final;
    }
}