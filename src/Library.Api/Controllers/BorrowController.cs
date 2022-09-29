using Library.Application.DTO;
using Library.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowedService _borrowedService;
        public BorrowController(IBorrowedService borrowedService)
        {
            _borrowedService = borrowedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowedDto>>> Get()
        {
            var borrowed = await _borrowedService.GetBorrowedAsync();
            return Ok(borrowed);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowedDto>> Get(int id)
        {
            var borrowed = await _borrowedService.GetBorrowedByIdAsync(id);
            return Ok(borrowed);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateBorrowedDto newBorrowed)
        {
            await _borrowedService.AddBorrowedAsync(newBorrowed);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBorrowedDto updateBorrowed)
        {
            await _borrowedService.UpdateBorrowedAsync(updateBorrowed);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _borrowedService.DeleteBorrowedAsync(id);
            return NoContent();
        }
    }
}
