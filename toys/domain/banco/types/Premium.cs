using Inputs;
using toys.utils;

namespace toys.banco.types;

public class Investments : BaseAccount
{
    public Investments(int id, string holder, double balance, double specialCheck) : base(id, AccountType.Investments,
        holder, balance, specialCheck)
    {
    }

    public override bool Sake(SakeCallback? callback = null)
    {
        return base.Sake(SakeCallback);
    }

    private double SakeCallback(double startValue)
    {
        if (startValue > 1000)
            return startValue;

        var final = startValue * 1.02;
        Console.WriteLine("Since the value is lower than $1000, it will have a 02% tax");
        var proceed = Input.BoolEnglish($"Withdraw ${startValue} with tax is ${final}. Continue [y/n]? ");

        if (!proceed)
            throw new MyError("Withdraw cancelled!");
        return final;
    }
}