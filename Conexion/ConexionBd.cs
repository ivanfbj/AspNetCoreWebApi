namespace AspNetCoreWebApi.Conexion
{
    public class ConexionBd
    {
        private string connectionString = string.Empty;
        public ConexionBd()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json").Build();
            
            connectionString = constructor.GetSection
                ("ConnectionStrings:MasterConnection").Value;

        }
        public string CadenaSQL()
        {
            return connectionString;
        }
    }
}
