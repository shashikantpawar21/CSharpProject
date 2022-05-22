using System.Reflection;

class DataProcessorFactory
{
    Dictionary<string, Type> DataProcessors;
    public DataProcessorFactory()
    {
        LoadDataProcessor();
    }
    public IDataProcessor CreateDataProcessor(string processingType)
    {

        Type type = GetType(processingType);
        if (type is null)
        {
            return null;
        }

        IDataProcessor dataProcessor = Activator.CreateInstance(type) as IDataProcessor;
        return dataProcessor;
    }

    private Type GetType(string processingType)
    {
        foreach (var key in DataProcessors.Keys)
        {
            if (key.ToLower() == processingType.ToLower())
                return DataProcessors[key];
        }
        return null;
    }
    private void LoadDataProcessor()
    {
        DataProcessors = new Dictionary<string, Type>();
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type dataProcessor in types)
        {
            if (dataProcessor.GetInterface(typeof(IDataProcessor).ToString()) != null)
                DataProcessors.Add(dataProcessor.Name.ToString(), dataProcessor);
        }
    }

    public void PrintProcessingTypes()
    {
        Console.Write("Available Processing Types are as :  ");
        foreach (var processingType in DataProcessors.Keys)
        {
            Console.Write("'" + processingType + "' ");
        }
        Console.WriteLine();
    }
}