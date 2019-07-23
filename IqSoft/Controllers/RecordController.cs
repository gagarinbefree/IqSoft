using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DataProvider;
using Services.Models;

namespace IqSoft.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        public RecordController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        // http://localhost:64281/api/v1/record/2019-07-23
        [HttpGet("{dateTime}", Name = "Get")]
        public async Task<IActionResult> Get(DateTime dateTime)
        {
            try
            {
                List<DomainRow> records = await _dataProvider.GetRecordsByUploadDateAsync(dateTime);
                if (!records.Any())
                    return NotFound();

                return Ok(records);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        // http://localhost:64281/api/v1/record/390a9061-71bb-4b83-9307-e4666a2e8319/col1/1000
        [HttpPut("{id}/{name}/{value}")]
        public async Task<IActionResult> Put(string id, string name, string value)
        {
            try
            {
                int count = await _dataProvider.UpdateRecordByIdAsync(id, name, value);
                if (count == 0)
                    return NotFound();

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // http://localhost:64281/api/v1/record/390a9061-71bb-4b83-9307-e4666a2e8319
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                int count = await _dataProvider.DeleteRecordByIdAsync(id);
                if (count == 0)
                    return NotFound();

                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
