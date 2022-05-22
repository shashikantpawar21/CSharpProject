public class TextFile : IDataProvider
{
    public string GetData(object filePath)
    {
        string message = "Data Source - TextFile --> Action - Get Data";
        Console.WriteLine(message);

        return message;
    }
}