using DocumentManagement.Models;
using DocumentManegemant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagement.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentModel>> List()
        {
            var document = await _context.Document
                .Include(x => x.Process)
                .OrderBy(x => x.Title)
                .ToListAsync();
            return document;
        }

        public async Task<bool> InsertDocument(DocumentModel document)
        {
            if (document == null)
            {
                return false;
            }

            _context.Add(document);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDocument(int id)
        {
            var document = await _context.Document.FindAsync(id);

            if (document != null)
            {
                _context.Document.Remove(document);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
