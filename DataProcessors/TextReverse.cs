public class TextReverse : IDataProcessor
{
    public object ProcessData(string data)
    {
        string message = "Processing Type - TextReverse --> Action - Process Data";
        Console.WriteLine(message);
        return message;
    }
}