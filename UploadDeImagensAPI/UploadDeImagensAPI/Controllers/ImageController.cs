
using Microsoft.AspNetCore.Mvc;
using UploadDeImagensAPI.Azure;
using UploadDeImagensAPI.DAO;
using UploadDeImagensAPI.DTO;

namespace UploadDeImagensAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateImage([FromBody] ImageDTO dto)
        {
            var azureBlobStorage = new AzureBlobStorage();
            var dao = new ImageDAO();

            dto.URL = azureBlobStorage.UploadImage(dto.Base64);
            dao.Cadastrar(dto);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dao = new ImageDAO();
            var images = dao.GetAll();
            return Ok(images);
        }
    }
}
