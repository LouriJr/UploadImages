using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UploadDeImagensAPI.DTO;

namespace UploadDeImagensAPI.DAO
{
    public class ImageDAO
    {
        public void Cadastrar(ImageDTO dto)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Images (Name, URL) Values (@name, @url)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@name", dto.Name);
            comando.Parameters.AddWithValue("@url", dto.URL);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public List<ImageDTO> GetAll()
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT*FROM Images";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var images = new List<ImageDTO>();

            while (dataReader.Read())
            {
                var image = new ImageDTO();
                image.ID = int.Parse(dataReader["ID"].ToString());
                image.Name = dataReader["Name"].ToString();
                image.URL = dataReader["URL"].ToString();

                images.Add(image);
            }
            conexao.Close();

            return images;
        }
    }
}
