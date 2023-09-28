using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System.IO;
using System.Text.RegularExpressions;
using System;

namespace UploadDeImagensAPI.Azure
{
    public class AzureBlobStorage
    {
        public string UploadImage(string image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=cadastrodeusuariosetec;AccountKey=EVzAf7pvRf63Togb1ua9fE2+c1QwSl5fSU+ow2rJed7zH6P8JXS6rKCYf6rFC/a4uECvJmaArbv9+AStsOE8fQ==;EndpointSuffix=core.windows.net";
            string containerName = "teste";

            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient(connectionString, containerName, fileName);

            var blobHttpHeader = new BlobHttpHeaders { ContentType = "image/jpg" };

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream, new BlobUploadOptions()
                {
                    HttpHeaders = blobHttpHeader,
                });
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
