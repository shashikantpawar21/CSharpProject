public class HttpUrl : IDataProvider
{
    public string GetData(object url)
    {
        string message = "Data Source - HttpUrl --> Action - Get Data";
        Console.WriteLine(message);

        return message;
    }
}