using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.ViewModels;

namespace MST_Service.Servvices.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentViewModel>> GetDocuments(string? search);
        Task<DocumentViewModel> GetDocument(Guid id);
        Task<DocumentViewModel> CreateDocument(DocumentCreateModel document);
        Task<DocumentViewModel> UpdateDocument(Guid id, DocumentUpdateModel document);
    }
}
