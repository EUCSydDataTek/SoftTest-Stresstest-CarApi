namespace CarApi.Data
{
    public class DatabaseSettings
    {
        public string DbName { get; set; } = string.Empty;

        public string DbUser { get; set; } = string.Empty;

        public string DbPassword { get; set; } = string.Empty;

        public int Dbport { get; set; } = 5432;

        public string DbAddress { get; set; } = "db";

        public string GetConnectionString()
        {
            return $"User ID={DbUser};Password={DbPassword};Host={DbAddress};Port={Dbport};Database={DbName};Pooling=true;Connection Lifetime=0;";
        }
    }
}
