using HeThongQuanLyTaiLieuDienTu_API.Data;
using HeThongQuanLyTaiLieuDienTu_API.Data.DTOs;
using HeThongQuanLyTaiLieuDienTu_API.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTaiLieuDienTu_API.Controllers
{
    public class DocumentController : BaseApiController
    {
        private readonly DataContext _context;

        public DocumentController(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            var stream = new MemoryStream(document.Content);

            return new FileStreamResult(stream, document.ContentType)
            {
                FileDownloadName = document.Name
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _context.Documents.ToListAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument([FromForm] DocumentDto model)
        {
            var document = new Document
            {
                Name = model.Name,
                ContentType = model.File.ContentType,
                CreatedAt = DateTime.UtcNow,
                Content = await GetFileContent(model.File)
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, [FromForm] DocumentUpdateDto model)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            document.Name = model.Name;
            document.ContentType = model.Content != null ? model.Content.ContentType : document.ContentType;
            document.UpdatedAt = DateTime.UtcNow;
            document.Content = model.Content != null ? await GetFileContent(model.Content) : document.Content;

            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<byte[]> GetFileContent(IFormFile file)
        {
            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}