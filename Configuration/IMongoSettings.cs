namespace ShitCoinParser.Configuration
{
    public interface IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string ShitDatabaseName { get; set; }
    }
}
