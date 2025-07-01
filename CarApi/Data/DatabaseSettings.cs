namespace CarApi.Data
{
    public class DatabaseSettings
    {
        public string DbName { get; set; } = "CarDb";

        public string DbUser { get; set; } = "postgres";

        public string DbPassword { get; set; } = "P@ssw0rd";

        public int Dbport { get; set; } = 5432;

        public string DbAddress { get; set; } = "db";

        public string GetConnectionString()
        {
            return $"User ID={DbUser};Password={DbPassword};Host={DbAddress};Port={Dbport};Database={DbName};Pooling=true;Connection Lifetime=0;";
        }
    }
}
