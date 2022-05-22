// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome, Data processing console application");
Console.WriteLine("--------------------------------------------");
DataProviderFactory dataProviderFactory = new DataProviderFactory();
dataProviderFactory.PrintDataSources();

DataProcessorFactory dataProcessorFactory = new DataProcessorFactory();
dataProcessorFactory.PrintProcessingTypes();
Console.WriteLine("--------------------------------------------");



if (args.Length <= 0 || args.Length <= 2)
{
    Console.WriteLine("No or less arguments provided");
}
else if (args.Length > 3)
{
    Console.WriteLine("Please provide required arguments only");
}
else
{

    IDataProvider dataProvider = dataProviderFactory.CreateDataProvider(args[0]);
    if (dataProvider is null)
    {
        Console.WriteLine("Data Source is not supported. Please check from the supported data sources and try again");
    }
    else
    {
        var dataProcessor = dataProcessorFactory.CreateDataProcessor(args[2]);
        if (dataProcessor is null)
        {
            Console.WriteLine("Processing Type is not available. Please check from the available processing types and try again");
        }
        else
        {
            Processor processor = new Processor(dataProvider, dataProcessor);
            processor.ProcessData(args[1]);
        }
    }
}




