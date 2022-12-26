using Microsoft.EntityFrameworkCore;
using MST_Service.Entities;
using MST_Service.Repositories.Implementations;
using MST_Service.Repositories.Interfaces;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.UnitOfWorks;
using MST_Service.ViewModels;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Document = MST_Service.Entities.Document;

namespace MST_Service.Servvices.Implementations
{
    public class DocumentService : BaseService, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _documentRepository = unitOfWork.Document;
        }

        public async Task<DocumentViewModel> CreateDocument(DocumentCreateModel document)
        {
            var id = Guid.NewGuid();
            var entry = new Document
            {
                Id = id,
                Name = document.Name,
                Description = document.Description,
                Url= document.Url,
                Status= document.Status,  

            };
            // Add lecture into db context
            _documentRepository.Add(entry);
            // Add lecture into database
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetDocument(id);
            }
            return null!;
        }

        public async Task<DocumentViewModel> GetDocument(Guid id)
        {
            return await _documentRepository
                .GetMany(document => document.Id.Equals(id))
                .Select(document => new DocumentViewModel
                {
                    Id = document.Id,
                    Name = document.Name,
                    Description = document.Description,
                }).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<DocumentViewModel>> GetDocuments(string? search)
        {
            return await _documentRepository
                .GetMany(document => document.Name.Contains(search ?? ""))
                .Select(document => new DocumentViewModel
                {
                    Id = document.Id,
                    Name = document.Name,
                    Description = document.Description,
                }).ToListAsync();
        }

        public async Task<DocumentViewModel> UpdateDocument(Guid id, DocumentUpdateModel document)
        {
            var currentDocument = await _documentRepository.GetMany(currentDocument => currentDocument.Id.Equals(id)).FirstOrDefaultAsync();
            if (currentDocument != null)
            {
                if (document.Name != null) currentDocument!.Name = document.Name;
                if (document.Description != null) currentDocument!.Description = document.Description;

                _documentRepository.Update(currentDocument!);
            }
            var result = await _unitOfWork.SaveChanges();
            if (result > 0)
            {
                return await GetDocument(id);
            }
            return null!;
        }

    }
}
