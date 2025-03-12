using Inputs;
using toys.utils;

namespace toys.banco.types;

public class Savings: BaseAccount
{
    public Savings(int id, string holder, double balance, double specialCheck) : base(id, AccountType.Savings, holder, balance, specialCheck) {}

    public override bool Sake(SakeCallback? callback = null)
    {
        return base.Sake(SakeCallback);
    }

    private double SakeCallback(double startValue)
    {
            var final = startValue * 1.02;
            var proceed = Input.BoolEnglish($"Withdraw ${startValue} with tax is ${final}. Continue [y/n]? ");

            if (!proceed)
                throw new MyError("Withdraw cancelled!");
            return final;
    }
}