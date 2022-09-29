using Library.Application.DTO;
using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly IReaderService _readerService;
        public ReadersController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderDto>>> Get()
        {
            var readers = await _readerService.GetAllReadersAsync();
            return Ok(readers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderDto>> Get(int id)
        {
            var reader = await _readerService.GetReaderByIdAsync(id);
            return Ok(reader);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery]ReaderDto newReader)
        {
            await _readerService.AddReaderAsync(newReader);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromQuery]UpdateReaderDto updateReader)
        {
            await _readerService.UpdateReaderAsync(updateReader);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _readerService.DeleteReaderAsync(id);
            return NoContent();
        }
    }
}
