using MST_Service.Entities;
using MST_Service.Repositories.Interfaces;

namespace MST_Service.Repositories.Implementations
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(MstContext context) : base(context)
        {
        }
    }
}
