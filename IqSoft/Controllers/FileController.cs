using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataProvider;

namespace IqSoft.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        public FileController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpPost]
        public async Task<IActionResult> PostXlsx(IFormFile file)
        {
            try
            {
                if (file == null)
                    throw new Exception("Empty file");

                if (file.Length == 0)
                    throw new Exception("Empty file");

                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                int countCell = await _dataProvider.UploadFileAsync(file.FileName, filePath);

                return Ok(new { file.Length, file.FileName, countCell });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
