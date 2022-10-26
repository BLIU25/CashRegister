namespace CashRegister
{
    public class Printer
    {
        public bool HasPrinted { get; set; }
        public void Print(string content)
        {
            // send message to a real printer
            HasPrinted = true;
        }
    }
}
