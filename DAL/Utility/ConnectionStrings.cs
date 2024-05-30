using Microsoft.Extensions.Configuration;

namespace DAL.Utility
{
    /// <summary>
    /// Scribe: 
    /// </summary>
    public class ConnectionStrings
    {        
        public ConnectionStrings()
        {             
            IConfigurationRoot configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(Directory.GetCurrentDirectory() + "/../Flavours-InvMgtPortal/appsettings.json").Build();
            SqlAppSettingConnection = configurationRoot.GetConnectionString("SQLDBConnection");            
        }
        private static string _sqlConnection = "Server=.\\sqlexpress;Database=FDMEPDB;Trusted_Connection=True;TrustServerCertificate=True";
        public static string SqlConnection { get => _sqlConnection; }
        public string SqlAppSettingConnection { get; set; }
    }
}
