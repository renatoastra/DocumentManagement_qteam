using DocumentManagement.Models;

namespace DocumentManagement.Repositories
{
    public interface IDocumentRepository
    {
        Task<bool> DeleteDocument(int id);
        Task<bool> InsertDocument(DocumentModel document);
        Task<List<DocumentModel>> List();
    }
}