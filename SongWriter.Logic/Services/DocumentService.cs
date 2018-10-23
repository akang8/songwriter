﻿using AutoMapper;
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
            dbModel.UserId = this.context.UserId;
            
            this.context.AppData.Add(dbModel);
            this.context.AppData.SaveChanges();

            return dbModel.Id;
        }

        public IEnumerable<DocumentSummary> GetAll()
        {
            var userId = this.context.UserId;
            var items = this.context.AppData.Documents
                                            .Where(d => d.UserId == userId)
                                            .ProjectTo<DocumentSummary>();

            return items;
        }

        public Document GetItem(int id)
        {
            var userId = this.context.UserId;
            var model = this.context.AppData.Documents
                                                    .Where(d => d.Id == id
                                                            && d.UserId == userId)
                                                    .ProjectTo<Document>()
                                                    .SingleOrDefault();

            return model;
        }

        public void Save(Document model)
        {
            var userId = this.context.UserId;
            var dbModel = this.context.AppData.Documents
                                                    .Where(d => d.Id == model.Id
                                                            && d.UserId == userId)
                                                    .SingleOrDefault();

            if(dbModel == null)
            {
                throw new InvalidOperationException("Cannot find item to update");
            }

            Mapper.Map(model, dbModel);

            this.context.AppData.SaveChanges();
        }

        public void Remove(int id)
        {
            var userId = this.context.UserId;
            var dbItem = this.context.AppData.Documents
                                                    .Where(d => d.Id == id
                                                            && d.UserId == userId)
                                                    .SingleOrDefault();
            this.context.AppData.Remove(dbItem);
            this.context.AppData.SaveChanges();
        }
    }
}
