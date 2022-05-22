public class WhitespaceCount : IDataProcessor
{
    public object ProcessData(string data)
    {
        string message = "Processing Type - WhitespaceCount --> Action - Process Data";
        Console.WriteLine(message);
        int whitespaceCount = 0;
        return whitespaceCount;

    }
}