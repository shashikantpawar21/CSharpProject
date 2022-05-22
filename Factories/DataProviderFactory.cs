using System.Reflection;

class DataProviderFactory
{
    Dictionary<string, Type> DataProviders;
    public DataProviderFactory()
    {
        LoadDataProvider();
    }
    public IDataProvider CreateDataProvider(string dataSource)
    {
        Type type = GetType(dataSource);
        if (type is null)
        {
            return null;
        }

        IDataProvider dataProcessor = Activator.CreateInstance(type) as IDataProvider;
        return dataProcessor;
    }

    private Type GetType(string dataSource)
    {
        foreach (var key in DataProviders.Keys)
        {
            if (key.ToLower() == dataSource.ToLower())
                return DataProviders[key];
        }
        return null;
    }
    private void LoadDataProvider()
    {
        DataProviders = new Dictionary<string, Type>();
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type dataProcessor in types)
        {
            if (dataProcessor.GetInterface(typeof(IDataProvider).ToString()) != null)
                DataProviders.Add(dataProcessor.Name.ToString(), dataProcessor);
        }
    }

    public void PrintDataSources()
    {
        Console.Write("Supported Data Sources are as :  ");
        foreach (var dataSource in DataProviders.Keys)
        {
            Console.Write(dataSource + "  ");
        }
        Console.WriteLine();
    }
}