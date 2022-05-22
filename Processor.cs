class Processor
{
    private readonly IDataProvider _dataProvider;
    private readonly IDataProcessor _dataProcessor;

    public Processor(IDataProvider dataProvider, IDataProcessor dataProcessor)
    {
        _dataProvider = dataProvider;
        _dataProcessor = dataProcessor;
    }
    public void ProcessData(object dataSource)
    {
        string data = _dataProvider.GetData(dataSource);
        _dataProcessor.ProcessData(data);
    }
}