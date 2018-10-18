using AutoMapper;
using AutoMapper.QueryableExtensions;
using SongWriter.Logic.Models;
using SongWriter.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data = SongWriter.Data.Models;

namespace SongWriter.Logic.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly AppLogicContext context;
        public DocumentService(AppLogicContext context)
        {
            this.context = context;
        }

        public int Add(Document model)
        {
            // Map to data model, and add to db
            var dbModel = Mapper.Map<data.Document>(model);
            this.context.AppData.Add(dbModel);

            return dbModel.Id;
        }

        public IEnumerable<Document> GetAll()
        {
            var items = this.context.AppData.Documents.ProjectTo<Document>();

            return items;
        }

        public Document GetItem(int id)
        {
            var model = this.context.AppData.Documents
                                                    .Where(d => d.Id == id)
                                                    .ProjectTo<Document>()
                                                    .SingleOrDefault();

            return model;
        }

        public void Save(Document model)
        {
            var dbModel = this.context.AppData.Documents
                                                    .Where(d => d.Id == model.Id)
                                                    .ProjectTo<Document>()
                                                    .SingleOrDefault();

            Mapper.Map(model, dbModel);

            this.context.AppData.SaveChanges();
        }
    }
}
