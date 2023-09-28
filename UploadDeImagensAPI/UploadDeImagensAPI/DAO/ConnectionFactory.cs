using MySql.Data.MySqlClient;

namespace UploadDeImagensAPI.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            return new MySqlConnection("Server=localhost;Database=UploadDeImagens;Uid=root;Pwd=root;");
        }
    }
}
