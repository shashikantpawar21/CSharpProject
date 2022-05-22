public class WordCount : IDataProcessor
{
    public object ProcessData(string data)
    {
        string message = "Processing Type - WordCount --> Action - Process Data";
        Console.WriteLine(message);
        int wordCount = 0;
        return wordCount;
    }
}