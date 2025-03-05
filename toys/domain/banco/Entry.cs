using toys.Data;

namespace toys.banco;

public class BankEntry(BankRepository br)
{
    private readonly BankRepository _br = br;

    public void Run()
    {
    }
}