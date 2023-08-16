namespace DataVisualizerDashboard.Services
{
    public interface IDatabaseService
    {
        public List<dynamic> GetDataFromDatabase(string connectionString, string query);
    }
}
