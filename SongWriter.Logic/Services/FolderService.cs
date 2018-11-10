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
    public class FolderService : IFolderService
    {
        private readonly AppLogicContext context;
        public FolderService(AppLogicContext context)
        {
            this.context = context;
        }

        public int Add(Folder model)
        {
            // Map to data model, and add to db
            var dbModel = Mapper.Map<data.Folder>(model);
            this.context.AppData.Add(dbModel);
            this.context.AppData.SaveChanges();

            return dbModel.Id;
        }

        public IEnumerable<Folder> GetAll()
        {
            var items = this.context.AppData.Folders.ProjectTo<Folder>();

            return items;
        }

        public Folder GetItem(int id)
        {
            var model = this.context.AppData.Folders
                                                    .Where(d => d.Id == id)
                                                    .ProjectTo<Folder>()
                                                    .SingleOrDefault();

            return model;
        }

        public void Save(Folder model)
        {
            var dbModel = this.context.AppData.Folders
                                                    .Where(d => d.Id == model.Id)
                                                    .SingleOrDefault();

            Mapper.Map(model, dbModel);

            this.context.AppData.SaveChanges();
        }

        public void Remove(int id)
        {
            var dbItem = this.context.AppData.Folders.Find(id);
            this.context.AppData.Remove(dbItem);
            this.context.AppData.SaveChanges();
        }
    }
}
