namespace toys.banco;

public class Transference
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int ReceiverHolder { get; set; }
    public int SenderHolder { get; set; }
}