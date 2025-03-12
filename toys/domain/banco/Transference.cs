namespace toys.banco;

public class Transference
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; } = DateTime.Now;
    public string ReceiverHolder { get; set; } = string.Empty;
    public string SenderHolder { get; set; } = string.Empty;
    public double Amount { get; set; }
    public TransferType Type { get; set; } = TransferType.Transfer;
}

public enum TransferType
{
    Deposit,
    Withdraw,
    Undo,
    Transfer,
} 